import Vue from 'vue';
import VueResource from 'vue-resource';
import { API_ROOT } from '../config.js';
import store from './store';
import router from '../router';
import { Toast } from 'mint-ui';
Vue.use(VueResource);

// HTTP相关
Vue.http.options.crossOrigin = true;
Vue.http.options.timeout = 30 * 1000;
Vue.http.options.xhr = { withCredentials: true };
Vue.http.options.root = API_ROOT; // api地址请求前缀

// 全局路由拦截
Vue.http.interceptors.push(function (request, next) {
    request.params = request.params || {};
    let version_code = store.state.user.version_code
    if (version_code) {
        request.params.version = version_code;
    }

    //request.headers.set('X-CSRF-TOKEN', 'TOKEN');

    var auth_token = store.state.user.auth_token
    if (auth_token) {
        request.headers.set('Authorization', 'Bearer ' + auth_token);
    }

    next(function (response) {
        if (response.ok) {
            if (response.status === 200) {
                if (response.body.status !== 1)
                    Toast(response.body.message);

                response.body = response.body.result;
                // 正常返回
            }
        } else if (response.status === 401) {
            // 假设该请求后端返回错误代码为-2是需要登录的，则跳转至登录页面
            console.log(router.history.current.path)
            var path = router.history.current.path;
            router.replace({ path: '/user/login', query: { redirect: path } });
        }
        // else if (response.body.status === 4) {
        //     // 参数错误
        //     // alert(response.data.message);
        // } else if (response.body.status === 5) {
        //     // 程序异常
        //     alert(response.body.message);
        // }
        else {
            Toast('获取数据失败...');
            console.error(`${response.status}-${response.statusText}\n${response.url}`)
        }
    });
});
export default {
    async login({ commit, state }, params) {
        var res = await Vue.http.post('/api/account/signin', params);
        commit("SET_AUTH_TOKEN", res.body.auth_token);
        commit("SET_IS_LOGIN", true);
        return res.body != null;
    },
    async getActivityList({ commit, state }, params) {
        var res = await Vue.http.get('/api/activity', params);
        return res.body;
    },
    async getSession({ commit, state }, activityId) {
        var res = await Vue.http.get(`/api/activity/${activityId}/session`);
        return res.body;
    },
    async getHall({ commit, state }, id) {
        var res = await Vue.http.get('/api/cinema/halls/' + id);
        return res.body;
    },
    async selectSeat({ commit, state }, params) {
        var res = await Vue.http.post('/api/session/select-seats', params);
        return res.body;
    },
    async getSeats({ commit, state }, sessionId) {
        var res = await Vue.http.get(`/api/session/${sessionId}/seats`);
        return res.body;
    },
    async getTasks({ commit, state }, sessionId) {
        var res = await Vue.http.get(`/api/session/${sessionId}/tasks`);
        return res.body;
    },
    async taskCheckIn({ commit, state }, sessionId) {
        var res = await Vue.http.post(`/api/session/${sessionId}/checkIn`);
        return res.body;
    }
}
