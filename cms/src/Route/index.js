import Home from "../Pages/Home"
import Job from "../Pages/Job"
import Staff from "../Pages/Staff"

const publicRoute=[
    {path:"/",element:Home},
    {path:"/Job",element:Job},
    {path:"Staff",element:Staff}
   
  
    
  
  ]
  const privateRouter=[]
  export {publicRoute,privateRouter}