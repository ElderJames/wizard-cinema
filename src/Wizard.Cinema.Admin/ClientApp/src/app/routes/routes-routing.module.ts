import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { environment } from '@env/environment';
// layout
import { LayoutDefaultComponent } from '../layout/default/default.component';
import { LayoutFullScreenComponent } from '../layout/fullscreen/fullscreen.component';
import { LayoutPassportComponent } from '../layout/passport/passport.component';
// dashboard pages
import { DashboardV1Component } from './dashboard/v1/v1.component';
import { DashboardAnalysisComponent } from './dashboard/analysis/analysis.component';
import { DashboardMonitorComponent } from './dashboard/monitor/monitor.component';
import { DashboardWorkplaceComponent } from './dashboard/workplace/workplace.component';
// passport pages
import { UserLoginComponent } from './passport/login/login.component';
import { UserRegisterComponent } from './passport/register/register.component';
import { UserRegisterResultComponent } from './passport/register-result/register-result.component';
// single pages
import { CallbackComponent } from './callback/callback.component';
import { UserLockComponent } from './passport/lock/lock.component';
import { Exception403Component } from './exception/403.component';
import { Exception404Component } from './exception/404.component';
import { Exception500Component } from './exception/500.component';

//cinema pages
import { CinemaShows1Component } from './cinema/shows1/shows1.component';

import { HeadWizardsComponent } from './wizards/head-wizards/head-wizards.component';
import { DivisionsComponent } from './wizards/divisions/divisions.component';
import { ActivityListComponent } from './activity/list/activity-list.component';
import { ActivityDetailComponent } from './activity/detail/activity-detail.component';
import { ApplicantListComponent } from './activity/applicants/applicant-list.component';
import { SessionListComponent } from './cinema/sessions/session-list/session-list.component';
import { SessionEditComponent } from './cinema/sessions/session-edit/session-edit.component';;

import { JWTGuard } from '@delon/auth';

const routes: Routes = [
  {
    path: '',
    component: LayoutDefaultComponent,
    children: [
      { path: '', redirectTo: 'cinema/shows1', pathMatch: 'full', canActivate: [JWTGuard] },
      { path: 'cinema/shows1', component: CinemaShows1Component },
      { path: 'cinema/sessions', component: SessionListComponent },
      { path: 'cinema/sessions/add', component: SessionEditComponent, data: { title: '增加场次' } },
      { path: 'cinema/sessions/:id', component: SessionEditComponent, data: { title: '编辑场次' } },
      { path: 'wizards/head-wizards', component: HeadWizardsComponent },
      { path: 'activity', component: ActivityListComponent },
      { path: 'activity/add', component: ActivityDetailComponent, data: { title: '增加活动' } },
      { path: 'activity/:id', component: ActivityDetailComponent, data: { title: '编辑活动' } },
      { path: 'applicants', component: ApplicantListComponent },
      { path: 'divisions', component: DivisionsComponent },
      { path: 'dashboard', redirectTo: 'dashboard/v1', pathMatch: 'full' },
      { path: 'dashboard/v1', component: DashboardV1Component },
      { path: 'dashboard/analysis', component: DashboardAnalysisComponent },
      { path: 'dashboard/monitor', component: DashboardMonitorComponent },
      { path: 'dashboard/workplace', component: DashboardWorkplaceComponent },
      {
        path: 'widgets',
        loadChildren: './widgets/widgets.module#WidgetsModule',
      },
      { path: 'style', loadChildren: './style/style.module#StyleModule' },
      { path: 'delon', loadChildren: './delon/delon.module#DelonModule' },
      { path: 'extras', loadChildren: './extras/extras.module#ExtrasModule' },
      { path: 'pro', loadChildren: './pro/pro.module#ProModule' },
    ],
  },
  // 全屏布局
  {
    path: 'data-v',
    component: LayoutFullScreenComponent,
    children: [
      { path: '', loadChildren: './data-v/data-v.module#DataVModule' },
    ],
  },
  // passport
  {
    path: 'passport',
    component: LayoutPassportComponent,
    children: [
      {
        path: 'login',
        component: UserLoginComponent,
        data: { title: '登录', titleI18n: 'pro-login' },
      },
      {
        path: 'register',
        component: UserRegisterComponent,
        data: { title: '注册', titleI18n: 'pro-register' },
      },
      {
        path: 'register-result',
        component: UserRegisterResultComponent,
        data: { title: '注册结果', titleI18n: 'pro-register-result' },
      },
    ],
  },
  // 单页不包裹Layout
  { path: 'callback/:type', component: CallbackComponent },
  {
    path: 'lock',
    component: UserLockComponent,
    data: { title: '锁屏', titleI18n: 'lock' },
  },
  { path: '403', component: Exception403Component },
  { path: '404', component: Exception404Component },
  { path: '500', component: Exception500Component },
  { path: '**', redirectTo: 'dashboard' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: environment.useHash })],
  exports: [RouterModule],
})
export class RouteRoutingModule { }
