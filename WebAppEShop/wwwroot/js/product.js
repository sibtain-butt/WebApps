var productDataTable;
//working & syntax learned from course
//==================>method 1 start<==================
$(document).ready(function () {
    loadProductDataTable();
});

function loadProductDataTable() {
    productDataTable = $('#productDataTable').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "25%" },
            { data: 'isbn', "width": "15%" },
            { data: 'listPrice', "width": "10%" },
            { data: 'author', "width": "15%" },
            { data: 'categoryModelClass.name', "width": "10%" },
            {
                data: 'id', //this id is not productId in asp-rout-productId but
            //this int? id -> is like @obj.id [primaryKey] of ProductModelClass like we did it in
            //Views>>Product>>Index.cshtml -> asp-route-productId="@obj.id"
                //<a href="/asp-area/asp-controller/asp-action?asp-route-id=20"></a>
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/Admin/Product/Upsert?productId=${data}" class="btn btn-primary mx-2">
                    <i class="bi bi-pencil-square"></i> Edit </a >
                    <a onClick=Delete('/Admin/Product/Delete/${data}') class="btn btn-danger mx-2">
                    <i class="bi bi-trash-fill"></i> Delete </a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}
//==================>method 1 end<==================

/*
//working & syntax learned from official 
//website https://datatables.net/manual/ajax
//sample in website: 
//$('#myTable').DataTable({
//      ajax: '/api/myData' //=> this is the api link of GetAll() ->admin/product/getall
//      //https://jsonformatter.org/ to check the product json data
//  });
//==================>method 2 start<==================
$(document).ready(function () {
    $('#tblData').DataTable({
        ajax: {
            url: '/admin/product/getall'//,
            //dataSrc: 'data' //=> data will be in below comments. 
            //Note: this method2 runs perfect without dataSrc: 'data' line
        },
        columns: [
            { data: 'title', "width": "25%" },
            { data: 'isbn', "width": "15%" },
            { data: 'listPrice', "width": "10%" },
            { data: 'author', "width": "20%" },
            { data: 'categoryModelClass.name', "width": "15%" }
        ]
    });
});
//==================>method 2 end<==================
*/

//function for Delete Method using [HttpDelete]>> in ProductController.cs file inside API CALLS
function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            /*Swal.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            )*/
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    //toastr.success(data.message);
                    productDataTable.ajax.reload()
                    const Toast = Swal.mixin({
                        toast: true,
                        position: 'top-end',
                        showConfirmButton: false,
                        timer: 3000,
                        timerProgressBar: true,
                        didOpen: (toast) => {
                            toast.addEventListener('mouseenter', Swal.stopTimer)
                            toast.addEventListener('mouseleave', Swal.resumeTimer)
                        }
                    })

                    Toast.fire({
                        icon: 'success',            
                        //title: '@TempData["tempDataKeySuccess"]'
                        title: data.message
                })

                }
            })
        }
    })
}



//=> dataSrc: 'data' // below is the data
//we don't need to write data here because data is getting from 
//ajax link==> ajax: { url: '/admin/product/getall' },

/*{
    "data": [
        {
            "id": 1,
            "title": "Fortune of Time",
            "description": "<p>Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies. Nunc malesuada viverra ipsum sit amet tincidunt.</p>",
            "isbn": "SWD9999001",
            "author": "Billy Spark",
            "listPrice": 99,
            "price": 90,
            "price50": 85,
            "price100": 80,
            "imageUrl": "\\images\\product\\60013ba5-8ce7-49d3-9203-021a49566388.jpg",
            "categoryId": 1016,
            "categoryModelClass": {
                "id": 1016,
                "name": "Action",
                "displayOrder": 1
            }
        },
        {
            "id": 2,
            "title": "Dark Skies",
            "description": "<p>Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies. Nunc malesuada viverra ipsum sit amet tincidunt.</p>",
            "isbn": "CAW777777701",
            "author": "Nancy Hoover",
            "listPrice": 40,
            "price": 30,
            "price50": 25,
            "price100": 20,
            "imageUrl": "\\images\\product\\099c52f4-bc23-44c0-a5f5-57268d58f600.jpg",
            "categoryId": 1017,
            "categoryModelClass": {
                "id": 1017,
                "name": "Sci-fi",
                "displayOrder": 2
            }
        },
        {
            "id": 3,
            "title": "Vanish in the Sunset",
            "description": "<p>Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies. Nunc malesuada viverra ipsum sit amet tincidunt.</p>",
            "isbn": "RITO5555501",
            "author": "Julian Button",
            "listPrice": 55,
            "price": 50,
            "price50": 40,
            "price100": 35,
            "imageUrl": "\\images\\product\\c7b4b56c-af66-407c-8f43-c0a04c3441d3.jpg",
            "categoryId": 1018,
            "categoryModelClass": {
                "id": 1018,
                "name": "History",
                "displayOrder": 3
            }
        },
        {
            "id": 4,
            "title": "Cotton Candy",
            "description": "<p>Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies. Nunc malesuada viverra ipsum sit amet tincidunt.</p>",
            "isbn": "WS3333333301",
            "author": "Abby Muscles",
            "listPrice": 70,
            "price": 65,
            "price50": 60,
            "price100": 55,
            "imageUrl": "\\images\\product\\04a910a2-88c5-4d56-b899-c73edd5583ee.jpg",
            "categoryId": 1019,
            "categoryModelClass": {
                "id": 1019,
                "name": "Horror",
                "displayOrder": 4
            }
        },
        {
            "id": 5,
            "title": "Rock in the Ocean",
            "description": "<p>Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies. Nunc malesuada viverra ipsum sit amet tincidunt.</p>",
            "isbn": "SOTJ1111111101",
            "author": "Ron Parker",
            "listPrice": 30,
            "price": 27,
            "price50": 25,
            "price100": 20,
            "imageUrl": "\\images\\product\\96e812b9-50e7-446a-bb78-f41b67f734d2.jpg",
            "categoryId": 1020,
            "categoryModelClass": {
                "id": 1020,
                "name": "Mystery",
                "displayOrder": 5
            }
        },
        {
            "id": 6,
            "title": "Leaves and Wonders",
            "description": "<p>Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies. Nunc malesuada viverra ipsum sit amet tincidunt.</p>",
            "isbn": "FOT000000001",
            "author": "Laura Phantom",
            "listPrice": 25,
            "price": 23,
            "price50": 22,
            "price100": 20,
            "imageUrl": "\\images\\product\\5c457554-05a2-4183-83b2-404c54ddf4b1.jpg",
            "categoryId": 1021,
            "categoryModelClass": {
                "id": 1021,
                "name": "Comedy",
                "displayOrder": 6
            }
        },
        {
            "id": 20,
            "title": "create update",
            "description": "<p>asfasf</p>\r\n<p>asdfasdfasdf</p>\r\n<p>asdfsdfasdf</p>",
            "isbn": "aasdf1100",
            "author": "Sibtain",
            "listPrice": 1000,
            "price": 123,
            "price50": 123,
            "price100": 123,
            "imageUrl": "\\images\\product\\c78b0e81-dc2d-44dd-9930-62ecca7e4a8e.jpg",
            "categoryId": 1016,
            "categoryModelClass": {
                "id": 1016,
                "name": "Action",
                "displayOrder": 1
            }
        },
        {
            "id": 21,
            "title": "Thousand Demon Dagger",
            "description": "<p>haha</p>",
            "isbn": "aasdf1100",
            "author": "Unknown",
            "listPrice": 1000,
            "price": 123,
            "price50": 123,
            "price100": 123,
            "imageUrl": "\\images\\product\\51274682-1c0c-4bab-99f8-f3817a23e8f0.jpg",
            "categoryId": 1016,
            "categoryModelClass": {
                "id": 1016,
                "name": "Action",
                "displayOrder": 1
            }
        }
    ]
}*/



