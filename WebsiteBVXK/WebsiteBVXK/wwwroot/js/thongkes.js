
var today = new Date();
var dd = today.getDate();
var mm = today.getMonth() + 1; //January is 0!
var yyyy = today.getFullYear();

if (dd < 10) {
    dd = '0' + dd;
}

if (mm < 10) {
    mm = '0' + mm;
}

today = yyyy + '-' + mm + '-' + dd;

document.getElementById("den-ngay").setAttribute("max", today);
document.getElementById("tu-ngay").setAttribute("max", today);



var app = new Vue({
    el: "#thong-ke-doanh-thu",
    data: {
        thongkes: [],
        thongkeModel: {
            IdVe: 0,
            NgayDat: "",
            LoaiVe: 0,
            GiaVe: 0,
            SoLuong: 0,
            IdDonHang: 0,
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