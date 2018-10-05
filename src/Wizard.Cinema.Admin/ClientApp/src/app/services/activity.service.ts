import { Injectable } from '@angular/core';
import { _HttpClient } from '@delon/theme';

@Injectable()
export class ActivityService {

    constructor(private http: _HttpClient) { }

    /**
     * 获取活动列表
     */
    getActivities = async (size: number, page: number, divisionId: number = null): Promise<any> => {
        return new Promise((resolve, reject) => {
            this.http.get('api/activity', { DivisionId: divisionId, PageNow: page, PageSize: size })
                .subscribe((res) => {
                    resolve(res);
                })
        })
    }
}