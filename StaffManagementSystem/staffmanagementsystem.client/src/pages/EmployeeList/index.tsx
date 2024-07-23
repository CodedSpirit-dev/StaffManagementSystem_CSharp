import { Table, TableBody, TableCell, TableHead, TableHeaderCell, TableRow } from "@tremor/react";
import { useEffect, useRef, useState } from "react";
import { IEmployeeData } from "../../utils/interfaces";
import EmployeeManagement from "../EmployeeCreate";
import axios from "axios";

function EmployeeList() {
    const [employees, setEmployees] = useState<IEmployeeData[]>([]);
    const [selectedEmployee, setSelectedEmployee] = useState<IEmployeeData | null>(null);

    useEffect(() => {
        FetchAllEmployees();
    }, []);


    const formRef = useRef<HTMLDivElement>(null);
    const scrollToElement = () => {
        setTimeout(() => {
            formRef.current?.scrollIntoView({ behavior: 'smooth' });
        }, 10); // Wait for the DOM to be updated
    };

    const contents = employees.length === 0
        ? <p><em>Loading...</em></p>
        : <div className="mx-auto max-w-2xl my-3">
            <Table className="">
                <TableHead className="table-auto border border-slate-300 border-opacity-70 divide-tremor-content-emphasis">
                    <TableRow>
                        <TableHeaderCell>Identificador</TableHeaderCell>
                        <TableHeaderCell>Nombre</TableHeaderCell>
                        <TableHeaderCell>Apellido</TableHeaderCell>
                        <TableHeaderCell>Numero de telefono</TableHeaderCell>
                        <TableHeaderCell>Departamento</TableHeaderCell>
                        <TableHeaderCell>Activo</TableHeaderCell>
                        <TableHeaderCell>Tiene seguro</TableHeaderCell>
                        <TableHeaderCell>Acciones</TableHeaderCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {employees.map((employee, index) =>
                        <TableRow key={employee.socialSecurityNumber} className={index % 2 === 0 ? 'row-even' : 'row-odd'}>
                            <TableCell className="text-center">{employee.socialSecurityNumber}</TableCell>
                            <TableCell>{employee.firstName}</TableCell>
                            <TableCell>{employee.lastName}</TableCell>
                            <TableCell className="text-center">{employee.contactInfo.phoneNumber}</TableCell>
                            <TableCell>{employee.employmentDetails.department}</TableCell>
                            <TableCell className="text-center">{employee.employmentDetails.isActive ? "Si" : "No"}</TableCell>
                            <TableCell className="text-center">{employee.employmentDetails.insuranceActive ? "Si" : "No"}</TableCell>
                            <TableCell>
                                <button onClick={() => {
                                    setSelectedEmployee(employee);
                                    scrollToElement();
                                }} className="button_blue_fixed_size">Editar</button>
                                <button onClick={() => DeactivateEmployee(employee)} className="button_yellow_fixed_size">Activar/Desactivar</button>
                            </TableCell>
                        </TableRow>
                    )}
                </TableBody>
            </Table>
        </div>;

    return (
        <div>
            <h1 className="text-2xl font-extrabold">Employee List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
            <div ref={formRef} />
            {selectedEmployee && <EmployeeManagement employee={selectedEmployee}/>}
        </div>
    );

    async function FetchAllEmployees() {
        const response = await axios.get('api/Employees');
        setEmployees(response.data);
    }

    async function DeactivateEmployee(employee: IEmployeeData) {
        await axios.patch(`api/Employees/${employee.socialSecurityNumber}/deactivate/`);
    }
}

export default EmployeeList;
