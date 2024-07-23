import { Link } from "react-router-dom";

export const NavBar = () => {
    return (
        <nav className="bg-white border-gray-200 dark:bg-gray-900 items-center">
            <div className="w-full py-3 border-b border-gray-200">
            <ul className="ml-3 flex xl:gap-10 md:gap-8 hover:text-white gap-2 font-medium hover:text-white text-gray-900">
                <li>
                    <Link to="/" className="hover:text-white">Inicio</Link>
                </li>
                <li>
                    <Link to="/lista" className="hover:text-white">Empleados</Link>
                </li>
                <li>
                    <Link to="/crearUsuario" className="hover:text-white">Crear Empleado</Link>
                </li>
            </ul>
            </div>
        </nav>
    );
}