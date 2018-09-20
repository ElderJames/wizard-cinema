import { Component, OnInit, ViewEncapsulation, ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { SimpleTableColumn } from '@delon/abc';
import { getTimeDistance, yuan } from '@delon/util';
import { _HttpClient } from '@delon/theme';

@Component({
    selector: 'app-dashboard-shows',
    templateUrl: './shows1.component.html',
    encapsulation: ViewEncapsulation.None,
    styleUrls: ['./shows1.component.less']
})
export class CinemaShows1Component implements OnInit {
    constructor(private http: _HttpClient, public msg: NzMessageService, private cd: ChangeDetectorRef) { }

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

    selectedSeats: any[] = [];

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

    openSeatSelector() {
        if (!window)
            return;

        var win = window.open("/SeatSelector", "", 'width=1200,height=630,left=300,top=100,location=no');
        win.onload = () => {
            var okbtn = win.document.getElementById('ok');
            var selectSeats = win.document.getElementById('selected-seat');
            okbtn.addEventListener('click', () => {
                this.selectedSeats = [];
                var json = selectSeats.getAttribute("value");
                if (json)
                    this.selectedSeats = JSON.parse(selectSeats.getAttribute("value"));
            })
        }
        win.onunload = () => {
            this.cd.markForCheck();
            this.cd.detectChanges();
        }
    }
}
