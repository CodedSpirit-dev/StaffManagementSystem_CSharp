import { Route, Routes } from 'react-router-dom';
import Home from './pages/Home';
import { NavBar } from './components/NavBar/NavBar';
import EmployeeManagement from './pages/EmployeeCreate';
import { Footer } from './components/Footer/Footer';
import ActiveEmployeeList from './pages/EmployeeList';

function App() {
        return (
            <>
            <NavBar />
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/lista" element={<ActiveEmployeeList />} />
                    <Route path="/crearUsuario" element={<EmployeeManagement/>} />
                </Routes>
                <Footer />
            </>
        );
    }
export default App;