<template>
    <div>
        <h3>Log In</h3>
        <form @submit.prevent>
            <div class="form-group">
                <label>Email</label>
                <br/>
                <input 
                    v-bind:value="login"
                    @input = "login = $event.target.value"
                    class="form-control" 
                    type="text"
                    placeholder="Email"
                    />
            </div>
            <div class="form-group">
                <label>Password</label>
                <br/>
                <input
                    v-bind:value="password"
                    @input="password = $event.target.value"
                    class="form-control"
                    type="password"
                    placeholder="Password"
                    />
            </div>
            <div class="form-group">
                <button
                    @click="loginPost"
                    type="submit"
                    class="m-2 btn btn-outline-dark"
                    >Log In</button>
                <button
                    @click="logout"
                    type="submit"
                    class="m-2 btn btn-outline-dark"
                    >Log Out</button>
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                login: "",
                password: "",
            }
        },
        methods: {
            loginPost() {
                try {
                    let response = fetch("Auth/loginData", {
                        method: "POST",
                        headers: { "Accept": "application/json", "Content-Type": "application/json" },
                        body: JSON.stringify({
                        email: this.login,
                        password: this.password
                        })
                    })
                    .then((response) => response.json())
                    .then( (data)=> {
                        sessionStorage.setItem("tokenKey", data.access_token);
                        sessionStorage.setItem("login", data.username);
                    });
                } catch(e) {
                    console.log("Ошибка");
                }
                this.password = "";
                this.login = "";
            },
            logout(){
                sessionStorage.removeItem("tokenKey");
                sessionStorage.removeItem("login");
            }
        }
    }
</script>