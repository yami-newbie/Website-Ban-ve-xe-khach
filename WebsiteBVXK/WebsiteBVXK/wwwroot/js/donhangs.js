var app = new Vue({
    el: "#quan-ly-don-hang",
    data: {
        from: "",
        to: "",
        objectIndex: 0,
        editing: false,
        loading: false,
        donhangs: [],
        donhangModel: {
            idDonHang: 0,
            idVeXe: 0,
            idXe: 0,
            idLichTrinh: 0,
            tenKhachHang: "",
            soDienThoai: "",
            gioDon: "",
            ngayDon: "",
            diemDon: "",
            diemTra: "",
            tongTien: 0,
            tinhTrang: ""
        }
    },
    mounted() {
        this.getDonHangs();
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
            this.loading = true;
            axios.delete("/DonHang/" + this.donhangModel.IdDonHang)
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
        }
    },
})