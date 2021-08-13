$(document).ready(function() {
    $("#idTable").DataTable({
        "ordering": true,
        "createdRow": function( row, data, dataIndex ) {
            const newdate = formatDate(data[4])
            row.getElementsByTagName("td")[4].innerText = newdate 
          }
    })
})

function formatDate(date) {
    const index = date.indexOf(" ")

    return date.substring(0, index)
}