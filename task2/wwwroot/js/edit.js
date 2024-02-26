function gethour(id, ssn) {
    $.ajax({
        url: `/Work/editscript?id=${id}&&ssn=${ssn}`,
        success: function (result) {
            console.log(`pno ${id} - ssn ${ssn}`)
            console.log(result);
            var area = document.getElementById("houres");
            area.innerHTML = result;
        }
    });
}