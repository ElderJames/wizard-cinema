import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CinermaService } from './cinema.service'
import { ActivityService } from './activity.service'
import { SessionService } from "./session.service";

@NgModule({
    providers: [
        CinermaService,
        ActivityService,
        SessionService
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
