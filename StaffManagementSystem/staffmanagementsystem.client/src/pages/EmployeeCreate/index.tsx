import { Form, FormProvider, useForm } from "react-hook-form";
import { EmployeeData } from "../../utils/interfaces";

export const EmployeeCreate: React.FC = () => {
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<EmployeeData>();

    const onSubmit = async (data: EmployeeData) => {
        console.log(data);
        // TODO: Call API to create employee
    };

    const onCreateEmployee = (data: EmployeeData) => {
        let employee: EmployeeData = {
            firstName: data.firstName,
            middleName: data.middleName,
            lastName: data.lastName,
            secondLastname: data.secondLastname,
            socialSecurityNumber: data.socialSecurityNumber,
            rfc: data.rfc,
            curp: data.curp,
            birthDate: data.birthDate,
            gender: data.gender,
            bloodType: data.bloodType,
            maritalStatus: data.maritalStatus,
            children: data.children,
            studyGrade: data.studyGrade,
            contactInfo: data.contactInfo,
            address: data.address,
            employmentDetails: data.employmentDetails,
            emergencyContact: data.emergencyContact
        };
        }
    }

    return (
        <div>
            <h1>Alta de empleados</h1>
            <h2>Aquí puedes dar de alta a nuevos empleados</h2>
            <FormProvider {...{ register, handleSubmit, errors }}>
                <Form
                    action="api/Employees/Create"
                    method="post"
                    content="application/json"
                    className="flex flex-col items-center"
                >
                    <div>
                        <div>
                            <h2>Datos Personales</h2>
                            <div className="grid grid-cols-2 gap-4">
                                <div>
                                    <label htmlFor="name">Nombre</label>
                                    <input
                                        type="text"
                                        id="name"
                                        className="input_text"
                                        {...register("firstName", { required: "Introduce el nombre" })}
                                    />
                                    {errors.firstName && <p className="error-message">{errors.firstName.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="middleName">Segundo nombre</label>
                                    <input
                                        type="text"
                                        id="middleName"
                                        className="input_text"
                                        {...register("middleName")}
                                    />
                                </div>
                                <div>
                                    <label htmlFor="lastName">Apellido</label>
                                    <input
                                        type="text"
                                        id="lastName"
                                        className="input_text"
                                        {...register("lastName", { required: "No olvides el apellido" })}
                                    />
                                    {errors.lastName && <p className="error-message">{errors.lastName.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="secondLastName">Segundo apellido</label>
                                    <input
                                        type="text"
                                        id="secondLastName"
                                        className="input_text"
                                        {...register("secondLastname")}
                                    />
                                </div>
                                <div>
                                    <label htmlFor="birthDate">Fecha de nacimiento</label>
                                    <input
                                        type="date"
                                        id="birthDate"
                                        className="input_date"
                                        {...register("birthDate", { required: "La fecha de nacimiento es obligatoria" })}
                                    />
                                    {errors.birthDate && <p className="error-message">{errors.birthDate.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="gender">Sexo</label>
                                    <select
                                        id="gender"
                                        className="input_text"
                                        {...register("gender", { required: "Selecciona el sexo" })}
                                    >
                                        <option value="male">Masculino</option>
                                        <option value="female">Femenino</option>
                                    </select>
                                    {errors.gender && <p className="error-message">{errors.gender.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="bloodType">Tipo de sangre</label>
                                    <select
                                        id="bloodType"
                                        className="input_text"
                                        {...register("bloodType", { required: "Selecciona el tipo de sangre" })}
                                    >
                                        <option value="A Positivo">A+</option>
                                        <option value="A Negativo">A-</option>
                                        <option value="B Positivo">B+</option>
                                        <option value="B Negativo">B-</option>
                                        <option value="AB Positivo">AB+</option>
                                        <option value="AB Negativo">AB-</option>
                                        <option value="O Positivo">O+</option>
                                        <option value="O Negativo">O-</option>
                                        <option value="Desconocido">Desconocido</option>
                                    </select>
                                    {errors.bloodType && <p className="error-message">{errors.bloodType.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="maritalStatus">Estado civil</label>
                                    <select
                                        id="maritalStatus"
                                        className="input_text"
                                        {...register("maritalStatus", { required: "El estado civil es requerido" })}
                                    >
                                        <option value="single">Soltero</option>
                                        <option value="married">Casado</option>
                                        <option value="widow">Viudo</option>
                                        <option value="divorced">Divorciado</option>
                                        <option value="otro">Otro</option>
                                    </select>
                                    {errors.maritalStatus && <p className="error-message">{errors.maritalStatus.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="children">Número de hijos</label>
                                    <input
                                        type="number"
                                        id="children"
                                        className="input_text"
                                        min={0}
                                        max={20}
                                        defaultValue={0}
                                        {...register("children", { required: "El número de hijos no debe estar vacío", min: { value: 0, message: "El número mínimo es 0" }, max: { value: 20, message: "El número máximo es 20" } })}
                                    />
                                    {errors.children && <p className="error-message">{errors.children.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="studyGrade">Ultimo grado de estudios</label>
                                    <select
                                        id="studyGrade"
                                        className="input_text"
                                        {...register("studyGrade", { required: "El ultimo grado de estudios es requerido" })}
                                    >
                                        <option value="primary">Primaria</option>
                                        <option value="secondary">Secundaria</option>
                                        <option value="highSchool">Bachillerato</option>
                                        <option value="university">Licenciatura</option>
                                        <option value="Masters">Maestría</option>
                                        <option value="Doctorate">Doctorado</option>
                                    </select>
                                    {errors.studyGrade && (
                                        <p className="error-message">{errors.studyGrade.message}</p>
                                    )}
                                </div>
                                <div>
                                    <label htmlFor="socialSecurityNumber">Número de seguro social</label>
                                    <input
                                        type="text"
                                        id="socialSecurityNumber"
                                        className="input_text"
                                        {...register("socialSecurityNumber", { required: "Por favor, introduce un número de seguro social." })}
                                    />
                                    {errors.socialSecurityNumber && <p className="error-message">{errors.socialSecurityNumber.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="rfc">RFC</label>
                                    <input
                                        type="text"
                                        id="rfc"
                                        className="input_text"
                                        {...register("rfc", { required: "Por favor, introduce un RFC." })}
                                    />
                                    {errors.rfc && <p className="error-message">{errors.rfc.message}</p>}
                                </div>
                                <div>


                                    <label htmlFor="curp">CURP</label>
                                    <input
                                        type="text"
                                        id="curp"
                                        className="input_text"
                                        {...register("curp", { required: "Por favor, introduce un CURP." })}
                                    />
                                    {errors.curp && <p className="error-message">{errors.curp.message}</p>}
                                </div>
                            </div>
                        </div>
                        <h3>Datos de contacto</h3>
                        <div>
                            <label htmlFor="email">Email</label>
                            <input
                                type="email"
                                id="email"
                                className="input_text"
                                {...register("contactInfo.email", { required: "Por favor, introduce un email válido." })}
                            />
                            {errors.contactInfo?.email && <p className="error-message">{errors.contactInfo.email.message}</p>}
                            <label htmlFor="phoneNumber">Número de teléfono</label>
                            <input
                                type="text"
                                id="phoneNumber"
                                className="input_text"
                                {...register("contactInfo.phoneNumber", { required: "Por favor, introduce un número de teléfono válido." })}
                            />
                            {errors.contactInfo?.phoneNumber && <p className="error-message">{errors.contactInfo.phoneNumber.message}</p>}
                        </div>
                        <h2>Domicilio</h2>
                        <div>
                            <label htmlFor="street">Calle</label>
                            <input type="text" id="street" className="input_text" {...register("address.addressLine", { required: "Por favor, introduce una calle." })} />
                            {errors.address?.addressLine && <p className="error-message">{errors.address.addressLine.message}</p>}
                            <label htmlFor="postalCode">Código postal</label>
                            <input type="number" id="postalCode" className="input_text" {...register("address.postalCode", { required: "Introduce un código postal." })} />
                            {errors.address?.postalCode && <p className="error-message">{errors.address.postalCode.message}</p>}
                            <label htmlFor="neighborhood">Colonia</label>
                            <input type="text" id="neighborhood" className="input_text" {...register("address.neighborhood", { required: "Por favor, introduce una colonia." })} />
                            {errors.address?.neighborhood && <p className="error-message">{errors.address.neighborhood.message}</p>}
                            <label htmlFor="city">Ciudad</label>
                            <input type="text" id="city" className="input_text" {...register("address.city", { required: "Por favor, introduce una ciudad." })} />
                            {errors.address?.city && <p className="error-message">{errors.address.city.message}</p>}
                            <label htmlFor="state">Estado</label>
                            <input type="text" id="state" className="input_text" {...register("address.state", { required: "Por favor, introduce un estado." })} />
                            {errors.address?.state && <p className="error-message">{errors.address.state.message}</p>}
                        </div>
                        <h2>Datos de trabajo</h2>
                        <div>
                            <label htmlFor="hireDate">Fecha de contratacion</label>
                            <input type="date" id="hireDate" className="input_text" {...register("employmentDetails.hiringDate", { required: "Por favor, introduce una fecha de contratacion." })} />
                            {errors.employmentDetails?.hiringDate && <p className="error-message">{errors.employmentDetails.hiringDate.message}</p>}
                            <label htmlFor="department">Departamento</label>
                            <input type="text" id="department" className="input_text" {...register("employmentDetails.department", { required: "Por favor, introduce un departamento." })} />
                            {errors.employmentDetails?.department && <p className="error-message">{errors.employmentDetails.department.message}</p>}
                            <label htmlFor="position">Posición</label>
                            <input type="text" id="position" className="input_text" {...register("employmentDetails.position", { required: "Por favor, introduce una posición." })} />
                            {errors.employmentDetails?.position && <p className="error-message">{errors.employmentDetails.position.message}</p>}
                            <label htmlFor="shift">Turno</label>
                            <input type="text" id="shift" className="input_text" {...register("employmentDetails.shift", { required: "Por favor, introduce un turno." })} />
                            {errors.employmentDetails?.shift && <p className="error-message">{errors.employmentDetails.shift.message}</p>}
                            <label htmlFor="bossName">Jefe</label>
                            <input type="text" id="bossName" className="input_text" {...register("employmentDetails.bossName", { required: "Por favor, introduce un jefe." })} />
                            {errors.employmentDetails?.bossName && <p className="error-message">{errors.employmentDetails.bossName.message}</p>}
                            <label htmlFor="salary">Contratado por:</label>
                            <input type="text" id="hiredBy" className="input_text" {...register("employmentDetails.hiredBy", { required: "Introduce quien está conratando al empleado." })} />
                            {errors.employmentDetails?.hiredBy && <p className="error-message">{errors.employmentDetails.hiredBy.message}</p>}
                            
                            // Si el archivo esta completo true, si no false
                            <label htmlFor="isFileComplete">Archivo completo</label>
                            <input type="checkbox" id="isFileComplete" className="input_text" {...register("employmentDetails.isFileComplete") } />
                            {errors.employmentDetails?.isFileComplete && <p className="error-message checkbox">{errors.employmentDetails.isFileComplete.message}</p>}

                            
                            <label htmlFor="notes">Notas</label>
                            <input type="text" id="notes" className="input_text" {...register("employmentDetails.notes")} />
                            {errors.employmentDetails?.notes && <p className="error-message">{errors.employmentDetails.notes.message}</p>}
                        </div>
                        <h2>Contacto de emergencia</h2>
                        <div>
                            <label htmlFor="emergencyContactName">Nombre</label>
                            <input type="text" id="emergencyContactName" className="input_text" {...register("emergencyContact.emergencyContactName", { required: "Por favor, introduce un nombre." })} />
                            {errors.emergencyContact?.emergencyContactName && <p className="error-message">{errors.emergencyContact.emergencyContactName.message}</p>}
                            <label htmlFor="emergencyPhone">Teléfono</label>
                            <input type="text" id="emergencyPhone" className="input_text" {...register("emergencyContact.emergencyPhone", { required: "Por favor, introduce un teléfono." })} />
                            {errors.emergencyContact?.emergencyPhone && <p className="error-message">{errors.emergencyContact.emergencyPhone.message}</p>}
                            <label htmlFor="emergencyRelationship">Parentesco</label>
                            <input type="text" id="emergencyRelationship" className="input_text" {...register("emergencyContact.emergencyRelationship", { required: "Por favor, introduce un parentesco." })} />
                            {errors.emergencyContact?.emergencyRelationship && <p className="error-message">{errors.emergencyContact.emergencyRelationship.message}</p>}
                        </div>
                    </div>
                    <button type="submit" className="p-2 bg-green-500 rounded-md" onClick={onCreateEmployee}>
                        Crear Empleado
                    </button>
                </Form>
            </FormProvider>
        </div>
    );
};
