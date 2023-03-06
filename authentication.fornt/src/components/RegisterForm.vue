<template>
    <div>
        <form @submit.prevent>
            <h3>Register</h3>
            <div class="form-group">
                <label>Email:</label>
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
                <label>Password:</label>
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
                <label>Confirm password:</label>
                <br/>
                <input
                    v-bind:value="confirm"
                    @input="confirm = $event.target.value"
                    class="form-control" 
                    type="password"
                    placeholder="Confirm password"
                    />
            </div>
            <div class="form-group">
                <button
                    @click="createUser"
                    type="submit"
                    class="m-2 btn btn-outline-dark"
                    >Register</button>
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
                confirm: ""
            }
        },
        methods: {
            createUser() {
                if (this.confirm==this.password)
                {
                    try {
                        
                        this.confirm = "";
                        let fetchData = {
                            method: 'POST',
                            body: JSON.stringify({"email": this.login,
                            "password": this.password}),
                            headers: {
                            'Content-Type': 'application/json'
                            }
                        }
                    fetch('Auth', fetchData)
                    } catch(e) {
                        console.log('Ошибка')
                    }                    
                }
                this.password = "";
                this.login = "";
                
            },
        }
    }
</script>