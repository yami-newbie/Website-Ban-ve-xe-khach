var app = new Vue({
    el: "quan-ly-ve",
    data: {
        editing: false,
        loading: false,
        objectIndex: 0,
        ticketViewModel: {
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
    method: {
        getTickets() {
            this.loading = true;
            axios.get("/QuanLyVe/")
        }
    }
})