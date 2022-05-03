

document.getElementById("den-ngay").max = new Date().toISOString().split("T")[0];
document.getElementById("tu-ngay").max = new Date().toISOString().split("T")[0];

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
        tongDoanhThu: "",
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
                    console.log("then")
                    this.calTongDoanhThu(res.data);
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
                        console.log("then")
                        this.calTongDoanhThu(res.data);
                    })
                    .catch(err => {
                        console.log(err)
                    })
            }
        },
        calTongDoanhThu(list) {
            var res = 0;
            list.map(x => res += x.giaVe);
            this.tongDoanhThu = res.toString() + " đ";
            console.log("tong doanh thu:", this.tongDoanhThu);
        }
    }
})