

var app = new Vue({
    el: "#quan-ly-don-hang",
    data: {
        objectIndex: 0,
        editing: false,
        loading: false,
        donhangs: [],
        tickets: [],
        donhangModel: {
            idDonHang: null,
            idVeXe: null,
            idXe: null,
            idLichTrinh: null,
            tenKhachHang: null,
            soDienThoai: null,
            gioDon: null,
            ngayDon: null,
            diemDon: null,
            diemTra: null,
            tongTien: null,
            tinhTrang: null,
            chuyenDi: null,
            soGhes: null,
            email: null,
        }
    },
    mounted() {
        this.getDonHangs();
        this.getTickets();
    },
    methods: {
        createLichTrinh() {
            loading = true;
            axios.post("/DonHang", this.donhangModel)
                .then(res => {
                    console.log(res);
                    this.donhangs.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    loading = false;
                });
        },
        getDonHangs() {
            loading = true;
            axios.get("/DonHang")
                .then(res => {
                    console.log(res);
                    this.donhangs = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    loading = false;
                });
        },
        getDonHang(id) {
            loading = true;
            axios.get("/DonHang/" + id)
                .then(res => {
                    console.log(res);
                    var donhang = res.data;
                    this.donhangModel = {
                        idDonHang: donhang.idDonHang,
                        idVeXe: donhang.idVeXe,
                        idXe: donhang.idXe,
                        idLichTrinh: donhang.idLichTrinh,
                        tenKhachHang: donhang.tenKhachHang,
                        soDienThoai: donhang.soDienThoai,
                        gioDon: donhang.gioDon,
                        ngayDon: donhang.ngayDon,
                        diemDon: donhang.diemDon,
                        diemTra: donhang.diemTra,
                        tongTien: donhang.tongTien,
                        tinhTrang: donhang.tinhTrang,
                        chuyenDi: donhang.chuyenDi,
                        soGhes: donhang.soGhes,
                        email: donhang.email,
                    }
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    loading = false;
                });
        },
        deleteDonHang() {
            if (this.donhangModel.tinhTrang == "Đã thanh toán") {
                return;
            }
            this.loading = true;
            axios.delete("/DonHang/" + this.donhangModel.idDonHang)
                .then(res => {
                    console.log(res.data);
                    this.donhangs.splice(this.objectIndex, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateDonHang() {
            if (this.donhangModel.idDonHang == null)
                return;
            this.loading = true;
            axios.put("/DonHang", this.donhangModel)
                .then(res => {
                    console.log(res.data);
                    this.donhangs.splice(this.objectIndex, 1, res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        editDonHang(id, index) {
            this.objectIndex = index;
            this.getDonHang(id);
            this.editing = true;
        },
        onMaVeChange() {
            axios.get("/QuanLyVe/tickets/" + this.donhangModel.idVeXe)
                .then(res => {
                    var ticket = res.data;
                    this.donhangModel.idXe = ticket.idXe;
                    this.donhangModel.idLichTrinh = ticket.idLichTrinh;
                })
                .catch(err => {
                    console.log(err);
                })
        },
        confirmSend(){
            sendEmail(
                body(this.donhangModel.tenKhachHang,
                    this.donhangModel.tongTien,
                    getTime(),
                    getDate(),
                    this.donhangModel.soDienThoai,
                    this.donhangModel.chuyenDi,
                    this.donhangModel.gioDon,
                    this.donhangModel.ngayDon,
                    this.donhangModel.diemDon,
                    this.donhangModel.diemTra,
                    this.donhangModel.soGhes),
                this.donhangModel.email,
                "Xác nhận thanh toán vé xe"
            );
        },
        thanhToanDon() {
            if (this.donhangModel.tinhTrang == 1 || this.donhangModel.idDonHang == null)
                return;
            this.loading = true;
            axios.put("/DonHang/ThanhToan/" + this.donhangModel.idDonHang)
                .then(res => {
                    console.log(res.data);
                    if (res.data == 1) {
                        console.log("done");
                        this.donhangModel.tinhTrang = "Đã thanh toán";
                        this.confirmSend();
                        this.getDonHangs();
                    }
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        getTickets() {
            this.loading = true;
            axios.get("/QuanLyVe/tickets")
                .then(res => {
                    console.log(res);
                    this.tickets = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
    },
})