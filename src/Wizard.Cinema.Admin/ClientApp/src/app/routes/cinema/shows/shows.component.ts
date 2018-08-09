import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { SimpleTableColumn } from '@delon/abc';
import { getTimeDistance, yuan } from '@delon/util';
import { _HttpClient } from '@delon/theme';

@Component({
    selector: 'app-dashboard-shows',
    templateUrl: './shows.component.html',
    styleUrls: ['./shows.component.less'],
})
export class CinemaShowsComponent implements OnInit {
    constructor(private http: _HttpClient, public msg: NzMessageService) { }

    ngOnInit() {

    }
}
