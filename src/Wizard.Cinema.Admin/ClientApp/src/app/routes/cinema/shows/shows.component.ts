import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { SimpleTableColumn } from '@delon/abc';
import { getTimeDistance, yuan } from '@delon/util';
import { _HttpClient } from '@delon/theme';

@Component({
    selector: 'app-dashboard-shows',
    templateUrl: './shows.component.html',
    encapsulation: ViewEncapsulation.None,
    styleUrls: ['./shows.component.less'],
})
export class CinemaShowsComponent implements OnInit {
    constructor(private http: _HttpClient, public msg: NzMessageService) { }

    loading = false;
    inputValue: string;
    options = [];

    tempKeyword = '';
    cityTimer: NodeJS.Timer;

    ngOnInit() {
    }

    onInput(value: string): void {
        console.log(value, this.options);

        if (value == '') {
            this.options = [];
            return;
        }

        if (this.tempKeyword == value && this.options.length == 0)
            return;

        clearTimeout(this.cityTimer);
        this.tempKeyword = value;
        this.loading = true;
        this.cityTimer = setTimeout(() => {
            this.http.get('api/cinema/city', { keyword: value })
                .subscribe((res: any) => {
                    this.loading = false;
                    this.options = res;
                })
        }, 500);

    }
}
