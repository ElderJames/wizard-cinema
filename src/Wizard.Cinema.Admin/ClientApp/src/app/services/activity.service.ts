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

    getDetail = async (activityId: number): Promise<any> => {
        return new Promise((resolve, reject) => {
            this.http.get('api/activity/' + activityId)
                .subscribe((res) => {
                    resolve(res);
                })
        })
    }

    getApplicants = async (size: number, page: number, activityId: number): Promise<any> => {
        return new Promise((resolve, reject) => {
            this.http.get('api/activity/' + activityId + '/applicants', {
                PageNow: page,
                PageSize: size
            }).subscribe((res) => {
                resolve(res);
            })
        })
    }

    importApplicantsFromWeidian = (activityId: number, formData: FormData): Promise<any> => {
        return new Promise((resolve, reject) => {
            this.http.post('api/activity/' + activityId + '/applicants/import-from-weidian', formData)
                .subscribe((res) => {
                    resolve(res);
                })
        })
    }
}