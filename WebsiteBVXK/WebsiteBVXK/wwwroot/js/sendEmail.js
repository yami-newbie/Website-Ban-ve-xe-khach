var app = new Vue({
	el: "#send-mail",
	data: {
		mailModel: {
			name: "test name",
			price: 123,
			time: "test time",
			date: "test date",
			phoneNumber: "test phonenumber",
			trip: "test trip",
			timePickUp: "test timepickup",
			datePickUp: "test datepickup",
			placePickUp: "test placepickup",
			destination: "test destination",
			seats: "test seats",
        }
    },
    methods: {
		send() {
			var content = this.mailModel;
			sendEmail(
				body(
					content.name,
					content.price,
					getDate(),
					getTime(),
					content.phoneNumber,
					content.trip,
					content.timePickUp,
					content.datePickUp,
					content.placePickUp,
					content.destination,
					content.seats));
        }
    }
})

