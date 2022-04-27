Date.prototype.yyyymmdd = function () {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return [this.getFullYear(),
    (mm > 9 ? '' : '0') + mm,
    (dd > 9 ? '' : '0') + dd
    ].join('-');
};

Date.prototype.hhmm = function () {
    var hh = this.getHours(); // getMonth() is zero-based
    var mm = this.getMinutes();

    return [(hh > 9 ? '' : '0') + hh,
    (mm > 9 ? '' : '0') + mm
    ].join(':');
};

var app = new Vue({
    el: "#quan-ly-lich-trinh",
    data: {
        //date: "yyyy-mm-dd"
        objectIndex: 0,
        editing: false,
        loading: false,
        from: 25,
        to: 12,
        date: null,
        lichtrinhModel: {
            IdLichTrinh: 0,
            IdXe: 0,
            NoiXuatPhat: "Đà Nẵng",
            NoiDen: "Hà Nội",
            NgayDi: "",//"2022-10-22",
            GioDi: "13:00",
            NgayDen: "2022-12-12",
            GioDen: "15:00",
        },
        lichtrinhs: []
    },
    mounted() {
        this.lichtrinhModel.NgayDi = new Date().yyyymmdd();
        this.lichtrinhModel.NgayDen = new Date().yyyymmdd();
        this.lichtrinhModel.GioDi = new Date().hhmm();
        this.lichtrinhModel.GioDen = new Date().hhmm();
        this.getLichTrinhs();
    },
    methods: {
        createLichTrinh() {
            loading = true;
            axios.post("/QuanLyLichTrinh", this.lichtrinhModel)
                .then(res => {
                    console.log(res);
                    this.lichtrinhs.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    loading = false;
                });
        },
        getLichTrinhs() {
            loading = true;
            axios.get("/QuanLyLichTrinh")
                .then(res => {
                    console.log(res);
                    this.lichtrinhs = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    loading = false;
                });
        },
        getLichTrinh(id) {
            loading = true;
            axios.get("/QuanLyLichTrinh/" + id)
                .then(res => {
                    console.log(res);
                    var lichtrinh = res.data;
                    this.lichtrinhModel = {
                        IdLichTrinh: lichtrinh.idLichTrinh,
                        IdXe: lichtrinh.idXe,
                        NoiXuatPhat: lichtrinh.noiXuatPhat,
                        NoiDen: lichtrinh.noiDen,
                        NgayDi: lichtrinh.ngayDi,//"2022-10-22",
                        GioDi: lichtrinh.gioDi,
                        NgayDen: lichtrinh.ngayDen,
                        GioDen: lichtrinh.gioDen,
                    }
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    loading = false;
                });
        },
        deleteLichTrinh() {
            this.loading = true;
            axios.delete("/QuanLyLichTrinh/" + this.lichtrinhModel.IdLichTrinh)
                .then(res => {
                    console.log(res.data);
                    this.lichtrinhs.splice(this.objectIndex, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateLichTrinh() {
            this.loading = true;
            axios.put("/QuanLyLichTrinh", this.lichtrinhModel)
                .then(res => {
                    console.log(res.data);
                    this.lichtrinhs.splice(this.objectIndex, 1, res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        editLichTrinh(id, index) {
            this.objectIndex = index;
            this.getLichTrinh(id);
            this.editing = true;
        }
    }
})