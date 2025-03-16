import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { publicRoute, privateRouter } from "./Route";
import RouteWrapper from "./Components/Common/routeWrapper";

function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          {[...publicRoute, ...privateRouter].map((route, index) => (
            <Route key={index} path={route.path} element={<RouteWrapper route={route} />}>
            </Route>
          ))}
        </Routes>
      </div>
    </Router>
  );
}

export default App;