import classNames from "classnames"
import Header from "../Components/Header";
import Footer from "../Components/Footer";
import LeftNavBar from "../Components/LeftNavBar"

function DefaultLayout({children}) {
    //const cx=classNames.bind(styles)
    return ( 
        <div  >
         
            <Header/>

            
        <div >
            <LeftNavBar/>
            <div>{children}</div>

        </div>
        
         
        
            <Footer/>
      
        </div>
     );
}

export default DefaultLayout;