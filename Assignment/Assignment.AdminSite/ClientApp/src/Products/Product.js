import React, { useState } from "react";
//import CreateNewProduct from "./CreateNewProduct";

function Product() {
const [productList, setproductList] = useState([]);
function GetAllProduct() {
const url = "http://localhost:5002/api/Product/GetAllProduct/";

fetch(url, {
    method: "GET",
})
    .then((response) => response.json())
    .then((reposnserFromServer) => {
    console.log(reposnserFromServer);
    setproductList(reposnserFromServer);
    })
    .catch((error) => {
    console.log(error);
    });
}
return (
<div className="table-responsive mt-5">
    <table className="table table-bordered border-dark">
    <thead>
        <tr>       
        <th scope="col">ProductName</th>
        <th scope="col">Price</th>
        <th scope="col">Description</th>
        <th scope="col">ImageTitle</th>
        <th scope="col">Action</th>
        </tr>
    </thead>
        <tbody>
        {productList.map((product) => (
        <tr key={product.id}>
            <td>{product.productName}</td>
            <td>{product.price}</td>
            <td>{product.description}</td>
            <td>
            <img src="{product.imageTitle}"></img>
            </td>
            <td>
                <button className="btn btn-dark btn-lg mx-3 my-3" >
                Update
                </button>
                <button className="btn btn-secondary btn-lg">Delete</button>
            </td>
        </tr>
        ))}
    </tbody>
    </table>
    <div>
    <button onClick={() => GetAllProduct()}>Get Products</button>
    </div>
    
</div>

);
}

export default Product;