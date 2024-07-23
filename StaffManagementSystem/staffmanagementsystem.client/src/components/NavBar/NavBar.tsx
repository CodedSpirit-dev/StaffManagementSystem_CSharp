import { Link } from "react-router-dom";

export const NavBar = () => {
    return (
        <nav className="bg-white border-gray-200 dark:bg-gray-900 items-center">
            <div className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4">
            <ul className="font-medium flex flex-col flex items-center md:p-0 mt-4 border border-gray-100 rounded-lg bg-gray-50 md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 md:border-0 md:bg-white dark:bg-gray-800 md:dark:bg-gray-900 dark:border-gray-700">
                <li>
                    <Link to="/" className="block py-2 px-3 text-white bg-blue-700 rounded md:bg-transparent md:text-blue-700 md:p-0 dark:text-white md:dark:text-blue-500">Inicio</Link>
                </li>
                <li>
                    <Link to="/lista" className="block py-2 px-3 text-white bg-blue-700 rounded md:bg-transparent md:text-blue-700 md:p-0 dark:text-white md:dark:text-blue-500">Empleados</Link>
                </li>
                <li>
                    <Link to="/crearUsuario" className="block py-2 px-3 text-white bg-blue-700 rounded md:bg-transparent md:text-blue-700 md:p-0 dark:text-white md:dark:text-blue-500">Crear Empleado</Link>
                </li>
            </ul>
            </div>
        </nav>
    );
}