<template lang="pug">
    Layout(:has_share="false" title="登录" :has_footer="false")
      mu-form(ref="form" :model="validateForm" class="login-form")
        mu-form-item(label="用户名" help-text="" prop="mobile" :rules="usernameRules")
          mu-text-field(v-model="validateForm.mobile" prop="mobile")
        mu-form-item(label="密码" prop="password" :rules="passwordRules")
          mu-text-field(type="password" v-model="validateForm.password" prop="password")
        mu-form-item(prop="rememberMe")
          mu-checkbox(label="记住我" v-model="validateForm.rememberMe")
        mu-form-item
          mu-button(color="primary" @click="submit") 提交
          mu-button(@click="clear") 重置
</template>

<script>
import Layout from "@/components/Layout";

export default {
  components: {
    Layout
  },
  data() {
    return {
      usernameRules: [
        { validate: val => !!val, message: "必须填写用户名" },
        { validate: val => val.length >= 3, message: "用户名长度大于3" }
      ],
      passwordRules: [
        { validate: val => !!val, message: "必须填写密码" },
        {
          validate: val => val.length >= 3 && val.length <= 10,
          message: "密码长度大于3小于10"
        }
      ],
      validateForm: {
        mobile: "",
        password: "",
        rememberMe: false
      }
    };
  },
  methods: {
    async submit() {
      var result = await this.$refs.form.validate();
      if (result) {
        var res = await this.$store.dispatch("login", this.validateForm);
        if (res) this.$router.replace(this.$route.query.redirect || "/");
      }
    },
    clear() {
      this.$refs.form.clear();
      this.validateForm = {
        mobile: "",
        password: "",
        rememberMe: false
      };
    }
  }
};
</script>
<style>
.login-form {
  width: 100%;
  padding: 2em;
  max-width: 460px;
}
</style>