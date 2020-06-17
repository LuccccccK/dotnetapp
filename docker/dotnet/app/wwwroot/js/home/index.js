document.addEventListener("DOMContentLoaded", function(){
    var app = new Vue({
        el: '#app',
        data: {
            message: 'Hello world',
            calculate_value_1: '',
            calculate_value_2: '',
            calculate_result: ''
        },
        methods:{
            calculate_click: function(){
                config = {
                    headers:{
                        'X-Requested-With': 'XMLHttpRequest',
                        'Content-Type':'application / x-www-form-urlencoded'
                    },
                    withCredentials:true,
                }
                param = {}

                let url = "/Home/Sample"
                axios.get(url, config)
                    .then(function(res){
                        app.calculate_result = res.data
                    })
                    .catch(function(res){
                        app.calculate_result = res.data
                    })
            }
        }
    })
});
