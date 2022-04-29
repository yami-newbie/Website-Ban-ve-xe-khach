var app = new Vue({
    el: "#tim-ve",
    data: {
        editing: false,
        loading: false,
        objectIndex: 0,
        findViewModel: {
            start: "",
            des: "",
            date: "",
        },
        result: []
    },
    mounted() {

    },
    methods: {
        findLichTrinh() {
            this.loading = true;
            axios.get("/TimKiem/" + this.findViewModel.start + "/" + this.findViewModel.des + "/" + this.findViewModel.date)
                .then(res => {
                    console.log(res);
                    value.data.kqViewModel.id = 10
                })
        },
        changeStart(start) {
            this.start = start
        },
    }
})
//var value = new Vue({
//    el: "#ket-qua",
//    data: {
//        editing: false,
//        loading: false,
//        kqViewModel: {
//            id: 0,
//            IdLichTrinh: 0,
//            IdXe: 0,
//            NoiXuatPhat: "",
//            NoiDen: "",
//            NgayDen: "",
//            GioDen: "",
//            NgayDi: "",
//            GioDi: "",
//        },
//    },
//    mounted() {
//        console.log(this.kqViewModel.id);
//    },
//})