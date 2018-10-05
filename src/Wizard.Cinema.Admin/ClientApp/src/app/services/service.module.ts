import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CinermaService } from './cinema.service'
import { ActivityService } from './activity.service'

@NgModule({
    providers: [
        CinermaService,
        ActivityService
    ],
})
export class ServiceModule {
    constructor(
        @Optional()
        @SkipSelf()
        parentModule: ServiceModule,
    ) {

    }
}
