import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CinermaService } from './cinema.service'

@NgModule({
    providers: [
        CinermaService
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
