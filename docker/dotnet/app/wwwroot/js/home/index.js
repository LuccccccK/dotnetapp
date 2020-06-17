document.addEventListener("DOMContentLoaded", function(){
    var app = new Vue({
        el: '#app',
        data: {
            value_1: '',
            value_2: '',
            result: ''
        },
        methods:{
            calculate: function(){
                config = {
                    headers:{
                        'X-Requested-With': 'XMLHttpRequest',
                        'Content-Type':'application / x-www-form-urlencoded'
                    },
                    withCredentials:true,
                }
                let params = new URLSearchParams();
                params.append('Value1', this.value_1);
                params.append('Value2', this.value_2);

                let url = "/Home/Calculate"
                axios.post(url, params, config)
                    .then(function(res){
                        if(res.data.errorFlg == true) {
                            app.result = res.data.errorMessage;    
                        } else {
                            app.result = res.data.result;
                        }
                    })
                    .catch(function(error){
                        console.log(error)
                    })
            }
        }
    })
});
