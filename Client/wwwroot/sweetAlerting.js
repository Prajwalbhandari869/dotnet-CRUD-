function createdAlert() {
    return new Promise(resolve => {
        Swal.fire({
            title: 'Created!',
            text: 'Click Ok to see created data.',
            icon: 'success'
        }).then((result) => {
            resolve(result.isConfirmed);
        })
    })
}
function deleteAlert() {
    return new Promise(resolve => {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Delete'
        }).then((result) => {
            resolve(result.isConfirmed);
        })
    })
}
function deleted() {
    Swal.fire({
        title: 'Deleted!',
        text: 'Your Data is sucessfully deleted.',
        icon: 'success'
    }).then((result) => {
        resolve(result.isConfirmed);
    })
}
function updated() {
    Swal.fire({
        title: 'Updated!',
        text: 'Your Data is sucessfully Updated.',
        icon: 'success'
    }).then((result) => {
        resolve(result.isConfirmed);
    })
}


