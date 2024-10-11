var dataTable;

$(document).ready(function () {
    loadDataTable();
});

dataTable = $('#tblData').DataTable({
    "ajax": { url: '/admin/product/getall' },
    "columns": [
        {
            "data": 'imageURL', "title": "Image", "width": "15%",
            "render": function (data, type, row) {
                return data ? `<img src="${data}" style="width:100px;">` : 'No image'; // 显示图片或替换文本
            }
        },
        { "data": 'productName', "title": "Product Name", "width": "15%" },
        {
            "data": 'listPrice', "title": "List Price", "width": "10%",
        },
        {
            "data": 'description', "title": "Description", "width": "15%",
            "render": function (data, type, row) {
                return data ? data : 'No description available'; // 替換 null 描述
            }
        },
        {
            "data": 'category.name', "title": "Category", "width": "15%",
            "render": function (data, type, row) {
                return data ? data : 'Uncategorized'; // 替換 null 分類
            }
        },
        { "data": 'categoryId', "title": "Category ID", "visible": false }, // ID 可能不顯示
        {
            "data": 'productId', "render": function (data) {
                return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>              
                     <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
            },
            "width":"25%"
        }
    ]
});

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'Delete',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}