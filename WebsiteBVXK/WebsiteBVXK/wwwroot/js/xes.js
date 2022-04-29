var app = new Vue({
    el: "#quan-ly-xe",
    data: {
        editing: false,
        loading: false,
        objectIndex: 0,
        xeViewModel: {
            idXe: null,
            tenTaiXe: null,
            loaiXe: null,
            soDienThoai: null,
            soLuongGhe: null,
            bienSo: null
        },
        xes: []
    },
    mounted() {
        this.getXes();
    },
    methods: {
        getXes() {
            this.loading = true;
            axios.get("/QuanLyXe/xes")
                .then(res => {
                    console.log(res);
                    this.xes = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        getXe(id) {
            this.loading = true;
            axios.get("/QuanLyXe/xes/" + id)
                .then(res => {
                    console.log(res);
                    var xe = res.data;
                    console.log(this.xeViewModel);
                    this.xeViewModel = {
                        idXe: xe.idXe,
                        tenTaiXe: xe.tenTaiXe,
                        loaiXe: xe.loaiXe,
                        soLuongGhe: xe.soLuongGhe,
                        soDienThoai: xe.soDienThoai,
                        bienSo: xe.bienSo
                    }
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateXe() {
            this.loading = true;
            try {
                axios.put("/QuanLyXe", this.xeViewModel/*, { headers: { 'Content-Type': 'application/json' } }*/)
                    .then(res => {
                        console.log(res.data);
                        this.xes.splice(this.objectIndex, 1, res.data);
                    })
                    .catch(err => {
                        console.log(err);
                    })
                    .then(() => {
                        this.loading = false;
                    });

            }
            catch (err) {
                console.log(err)
            }
        },
        createXe() {
            this.loading = true;
            axios.post("/QuanLyXe", this.xeViewModel, { headers: { 'Content-Type': 'application/json' } })
                .then(res => {
                    console.log(res.data);
                    this.xes.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },
        deleteXe() {
            this.loading = true;
            axios.delete("/QuanLyXe/" + this.xeViewModel.idXe)
                .then(res => {
                    console.log(res.data);
                    this.xes.splice(this.objectIndex, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        editProduct(id, index) {
            this.objectIndex = index;
            this.getXe(id);
            this.editing = true;
        },
        onLoaiXeChange(loaixe) {
            if (this.xeViewModel != null) {
                if (loaixe == 0) {
                    this.xeViewModel.soLuongGhe = "40 chỗ";
                }
                else {
                    this.xeViewModel.soLuongGhe = "32 chỗ";
                }
            }
        }
    }
})