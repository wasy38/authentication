<template>
  <div class="m-5 content ">
    <div class="row">
      <div class="col-sm-4">
        <PayloadForm class="controll"/>
      </div>
      <div class="col-sm-4">
        <RegisterForm class="controll"/>
      </div>
      <div class="col-sm-4">
        <AuthenticationInteraction class="controll"/>
      </div>
    </div>
  </div>
</template>

<script>
    import RegisterForm from '@/components/RegisterForm.vue'
    import PayloadForm from '@/components/PayloadForm.vue'
    import AuthenticationInteraction from '@/components/AuthenticationInteraction.vue'

export default {
  name: 'App',
        components: {
            AuthenticationInteraction,
            PayloadForm,
            RegisterForm
        }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
*{
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

</style>
