import { Injectable } from '@angular/core';
import { _HttpClient } from '@delon/theme';

@Injectable()
export class CinermaService {

    constructor(private http: _HttpClient) { }

    /**
     * 获取场次详情
     * @param id 场次id
     */
    getSession = async (id: number): Promise<any> => {
        return new Promise((resolve) => {
            this.http.get('api/session/' + id).subscribe(async (res: any) => {
                resolve(res);
            });
        })
    }

    /**
     * 获取分部列表
     * @param size 每页记录数
     * @param page 获取页数
     */
    getDivisions = async (size: number = 10, page: number = 1): Promise<any> => {
        return new Promise((resolve) => {
            this.http.get('api/division', { PageSize: size, PageNow: page })
                .subscribe((res: any) => {
                    // this.divisions = res.records;
                    resolve(res.records);
                })
        })
    }

    /**
     * 获取影厅详情
     * @param hallId 影厅ID
     */
    getHall = async (hallId: number): Promise<any> => {
        return new Promise((resolve) => {
            this.http.get('api/halls/' + hallId)
                .subscribe((res: any) => {
                    resolve(res);
                })
        })
    }

    /**
     * 获取某城市的影院列表
     * @param cityId 城市id
     */
    getCinemas(cityId: number, size: number = 10, page: number = 1): Promise<any[]> {
        return new Promise((resolve, reject) => {
            if (!cityId || cityId <= 0) {
                reject("请选择城市");
                return;
            }
            this.http.get('api/city/' + cityId + '/cinemas', { size: size, page: page })
                .subscribe((res: any) => {
                    resolve(res.records.map(x => {
                        return {
                            cinemaId: x.cinemaId,
                            value: x.cinemaId + '',
                            label: x.name,
                            isLeaf: false
                        };
                    }))
                }, (null), () => resolve(null))
        })
    }

    /**
     * 获取某影院的影厅
     * @param cinemaId 影院Id
     */
    getHalls(cinemaId: number): Promise<any[]> {
        return new Promise((resolve, reject) => {
            if (!cinemaId || cinemaId <= 0) {
                reject("请选择影院");
                return;
            }
            this.http.get("api/cinemas/" + cinemaId + "/halls")
                .subscribe((res: any) => {
                    resolve(res)
                }, null, () => resolve(null));
        })
    }
}