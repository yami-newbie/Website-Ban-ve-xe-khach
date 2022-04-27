var app = new Vue({
    el: "#thong-ke-doanh-thu",
    data: {
        thongkes: [],
        thongkeModel: {
            IdVe: 0,
            NgayDat: "",
            LoaiVe: 0,
            GiaVe: 0,
        },
        from: "",
        to: "",
    },
    mounted() {
        this.getThongKes();
    },
    methods: {
        getThongKes() {
            axios.get("/ThongKe")
                .then(res => {
                    console.log(res);
                    this.thongkes = res.data;
                })
                .catch(err => {
                    console.log(err)
                })
        },
        getThongKesBetween() {
            if (this.from != "" && this.to != "") {
                axios.get("/ThongKe/" + this.from + "/" + this.to)
                    .then(res => {
                        console.log(res);
                        this.thongkes = res.data;
                    })
                    .catch(err => {
                        console.log(err)
                    })
            }
        }
    }
})