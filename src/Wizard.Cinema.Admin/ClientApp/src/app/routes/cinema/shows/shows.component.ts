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

    list: any[] = [];
    q: any = {
        ps: 8,
        categories: [],
        owners: ['zxx'],
    };
    ngOnInit() {
        this.getData();
    }

    onInput(value: string): void {

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

    getData() {
        this.loading = true;
        this.http.get('/api/list', { count: this.q.ps }).subscribe((res: any) => {
            this.list = res.map(item => {
                item.activeUser = this.formatWan(item.activeUser);
                return item;
            });
            this.loading = false;
        });
    }

    private formatWan(val) {
        const v = val * 1;
        if (!v || isNaN(v)) return '';

        let result = val;
        if (val > 10000) {
            result = Math.floor(val / 10000);
            result = `${result}`;
        }
        return result;
    }
}
