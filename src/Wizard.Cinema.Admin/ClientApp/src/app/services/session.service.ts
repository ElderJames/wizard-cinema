import { Injectable } from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { async } from 'rxjs/internal/scheduler/async';
import { HttpHandler } from '@angular/common/http';

@Injectable()
export class SessionService {

    constructor(private http: _HttpClient) { }

    /**
     * 获取场次列表
     */
    getSessionList = async (size: number, page: number, divisionId: number = null): Promise<any> => {
        return new Promise((resolve, reject) => {
            this.http.get('api/session', { DivisionId: divisionId, PageNow: page, PageSize: size })
                .subscribe((res) => {
                    resolve(res);
                })
        })
    }

    beginSelect = async (sessionId: number): Promise<any> => {
        return new Promise((resolve, reject) => {
            this.http.post('api/session/begin-select', "sessionId=" + sessionId, null, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .subscribe((res) => {
                    resolve(res);
                })
        })
    }
}