import React from 'react';  
import Create from './Products/Create';  
import List from './Products/List';  
//import EditStudent from './Products/Edit';  
import { BrowserRouter as Router, Switch, Route, Link, Routes } from 'react-router-dom';  
import './App.css';  
function App() {  
  return (  
    <Router>  
      <div className="container">  
        <nav className="navbar navbar-expand-lg navheader">  
          <div className="collapse navbar-collapse" >  
            <ul className="navbar-nav mr-auto">  
              {/* <li className="nav-item">  
                <Link to={'/Create'} className="nav-link">Products</Link>  
              </li>   */}
              <li className="nav-item">  
                <Link to={'/List'} className="nav-link">Products List</Link>  
                <li>Hi</li>
              </li>  
            </ul>  
          </div>  
        </nav> <br />  
        
          <Routes>
            {/* <Route exact path='/Create' component={Create} />  
            <Route path='/edit/:id' component={EditStudent} />   */}
            <Route path='/List' component={List} />   
          </Routes> 
          
      </div>  
    </Router>  
  );  
}  

export default App;  