<template>
    <div>
        <form @submit.prevent>
            <h3>Invoke API</h3>
            <div class="form-group">
                <label>User</label>
                <input 
                    v-bind:value="email"
                    @input = "email = $event.target.value"
                    class="form-control" 
                    type="text"
                    readonly
                    />
            </div>
            <div class="form-group">
                <label>Result</label>
                <input 
                    v-bind:value="statuscode"
                    @input = "statuscode = $event.target.value"
                    class="form-control" 
                    type="text"
                    readonly
                    />
            </div>
            <div class="form-group">
                <button
                    @click="call"
                    type="submit"
                    class="m-2 btn btn-outline-dark"
                    >Call API</button>
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                email: "",
                statuscode: "",
            }
        },
        methods: {
            call() {
                try {
                    
                    const token = sessionStorage.getItem("tokenKey");
                    const response = fetch("Auth", {
                        method: "GET",
                        headers: {
                            "Accept": "application/json",
                            "Authorization": "Bearer " + token
                        }
                    })
                    .then((r)=>
                    {
                        this.email= sessionStorage.getItem("login");
                        this.statuscode=r.status;
                    }); 
                } catch(e) {
                    console.log("Ошибка")
                }                 
            },
        }
    }
</script>
