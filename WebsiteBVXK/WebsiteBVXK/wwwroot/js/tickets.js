var app = new Vue({
    el: "#quan-ly-ve",
    data: {
        editing: false,
        loading: false,
        objectIndex: 0,
        veViewModel: {
            idVe: 0,
            idXe: 0,
            idLichTrinh: 0,
            giaVe: 0,
            tinhTrang: 0,
            loaiVe: 0
        },
        tickets: []
    },
    mounted() {
        this.getTickets();
    },
    methods: {
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
        getTicket(id) {
            this.loading = true;
            axios.get("/QuanLyVe/tickets/" + id)
                .then(res => {
                    console.log(res);
                    var ve = res.data;
                    console.log(this.veViewModel);
                    this.veViewModel = {
                        idVe: ve.idVe,
                        idXe: ve.idXe,
                        idLichTrinh: ve.idLichTrinh,
                        giaVe: ve.giaVe,
                        tinhTrang: ve.tinhTrang,
                        loaiVe: ve.loaiVe
                    }
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateTicket() {
            this.loading = true;
            try {
                axios.put("/QuanLyVe", this.veViewModel)
                    .then(res => {
                        console.log(res.data);
                        this.tickets.splice(this.objectIndex, 1, res.data);
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
        createTicket() {
            this.loading = true;
            axios.post("/QuanLyVe", this.veViewModel, { headers: { 'Content-Type': 'application/json' } })
                .then(res => {
                    console.log(res.data);
                    this.tickets.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },
        deleteTicket() {
            this.loading = true;
            axios.delete("/QuanLyVe/" + this.veViewModel.idVe)
                .then(res => {
                    console.log(res.data);
                    this.tickets.splice(this.objectIndex, 1);
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
            this.getTicket(id);
            this.editing = true;
        },
    }
})