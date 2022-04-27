var app = new Vue({
    el: "#quan-ly-lich-trinh",
    data: {
        //date: "yyyy-mm-dd"
        from: 25,
        to: 12,
        lichtrinhModel: {
            IdLichTrinh: 0,
            IdXe: 0,
            NoiXuatPhat: 12,
            NoiDen: 45,
            NgayDi: "2022-12-22",
            NgayDen: "2022-13-12"
        },
        lichtrinhs: []
    },
    methods: {
        onchange() {
            console.log(this.date);
        }
    }
})