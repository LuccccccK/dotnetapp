document.addEventListener("DOMContentLoaded", function(){
    var app = new Vue({
        el: '#app',
        methods:{
            insert: function(){
                config = {
                    headers:{
                        'X-Requested-With': 'XMLHttpRequest',
                        'Content-Type':'application / x-www-form-urlencoded'
                    },
                    withCredentials:true,
                }
                let params = new URLSearchParams();

                let url = "/Database/Insert";
                axios.post(url, params, config)
                    .then(function(res){
                        console.log(res);
                    })
                    .catch(function(error){
                        console.log(error);
                        window.location.href = '/Home/Error';
                    })
            }
        }
    })
});
