import {useContext} from "react";
import { ThemeContext } from "./context/theme.context";
import Navbar from "./context/navbar/Navbar.component";


const App = () => {
const {darkMode} = useContext(ThemeContext);

const appStyles = darkMode ? "app dark" : "app";

  return (
    <div className={appStyles}>
        <Navbar/>
        <div className="wrapper">
            Routes
        </div>
    </div>
    
  )
}

export default App