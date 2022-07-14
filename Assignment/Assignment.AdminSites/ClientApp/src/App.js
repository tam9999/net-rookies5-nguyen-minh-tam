import React from 'react';  
import AddCategory from './Category/AddCategory';  
import CategoryList from './Category/CategoryList';  
import EditCategory from './Category/EditCategory'; 
import { Route, Routes } from 'react-router-dom'
import { Link } from 'react-router-dom';
import './App.css';  
function App() {  
  return (  
    <>  
      <div className="container">  
        <nav className="navbar navbar-expand-lg navheader">  
          <div className="collapse navbar-collapse" >  
            <ul className="navbar-nav mr-auto">  
              <li className="nav-item">  
                <Link to={'/AddCategory'} className="nav-link">Create Category</Link>  
              </li>  
              <li className="nav-item">  
                <Link to={'/CategoryList'} className="nav-link">Category List</Link>  
              </li>
            </ul>  
          </div>  
        </nav> <br />  
        <Routes>  
          <Route exact path='/AddCategory' element={<AddCategory />} />  
          <Route path='/edit/:categoryId' element={<EditCategory />} />  
          <Route path='/CategoryList' element={<CategoryList />} />  
        </Routes>  
      </div>  
    </>  
  );  
}  

export default App;  

// import React, { Component } from 'react';
// import { Route, Routes } from 'react-router-dom';

// import Sidebar from './components/Sidebar';
// import './App.css';
// import Product from './Products/Product';
// import Detail from './Products/Detail';
// export default class App extends Component {
//   static displayName = App.name;

//   render() {
//     return (
//     <>
        
//           <Detail />
//           <Sidebar />
//     </> 
//     );
//   }
// }


// export default class App extends Component {
//   static displayName = App.name;

//   render() {
//     return (
//       <Layout>
//       <Routes>
//         {AppRoutes.map((route, index) => {
//           const { element, ...rest } = route;
//           return <Route key={index} {...rest} element={element} />;
//         })}
//       </Routes>
//       </Layout>
//     );
//   }
// }