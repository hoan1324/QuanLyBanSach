import { BrowserRouter as Router,Route,Routes } from "react-router-dom";
import { Fragment } from "react";
import { publicRoute } from "./CommoHelper/Route";
import DefaultLayout from "./Components/Layout/DefaultLayout";

function App() {
  return (
  <Router>
    <div className="App">
    <Routes>
        {publicRoute.map((route,index)=>{
          let Layout=DefaultLayout
          if(route.layout){
            Layout=route.layout
          }
          else if(route.layout===null){
            Layout=Fragment
          }
          return (
            <Route key={index} path={route.path} 
            element={<Layout><route.element/></Layout>}>

            </Route>
          )
        })}
      </Routes>
    
    </div>
  </Router>
  );
}

export default App;