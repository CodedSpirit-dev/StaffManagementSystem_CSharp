import { FormProvider, useForm } from "react-hook-form";
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

  return (
    <div>
      <h1>Alta de empleados</h1>
      <h2>Aqui puedes dar de alta a nuevos empleados</h2>
      <FormProvider {...{ register, handleSubmit, errors }}>
      <form
        className="flex flex-col items-center"
        onSubmit={handleSubmit(onSubmit)}
      >
        <div className="space-y-12">
          <div>
            <h2>Datos Personales</h2>
            <div className="grid grid-cols-2 gap-4">
              <div>
                <label htmlFor="name">Nombre</label>
                <input
                  type="text"
                  id="name"
                  className="input_text"
                  {...register("firstName", { required: true })}
                />
                {errors.firstName && <p className="error-message">El nombre es requerido</p>}
              </div>
              <div>
                <label htmlFor="lastName">Segundo nombre</label>
                <input
                  type="text"
                  id="middleName"
                  className="input_text"
                  {...register("middleName", { required: true })}
                />
                {errors.middleName && <p className="error-message">El segundo nombre es requerido</p>}
              </div>
              <div>
                <label htmlFor="lastName">Apellido</label>
                <input
                  type="text"
                  id="lastName"
                  className="input_text"
                  {...register("lastName", { required: true })}
                />
                {errors.lastName && <p className="error-message">El apellido es requerido</p>}
              </div>
              <div>
                <label htmlFor="lastName">Segundo apellido</label>
                <input
                  type="text"
                  id="secondLastName"
                  className="input_text"
                  {...register("secondLastname", { required: true })}
                />
                {errors.secondLastname && (
                  <p className="error-message">El segundo apellido es requerido</p>
                )}
              </div>
              <div>
                <label htmlFor="birthDate">Fecha de nacimiento</label>
                <input
                  type="date"
                  id="birthDate"
                  className="input_date"
                  {...register("birthDate", { required: true })}
                />
                {errors.birthDate && <p className="error-message">La fecha de nacimiento es requerida</p>}
              </div>
              <div>
                <label htmlFor="gender">Sexo</label>
                <select
                  id="gender"
                  className="input_text"
                  {...register("gender", { required: true })}
                >
                  <option value="male">Masculino</option>
                  <option value="female">Femenino</option>
                </select>
                {errors.gender && <p className="error-message">El sexo es requerido</p>}
              </div>
              <div>
                <label htmlFor="bloodType">Tipo de sangre</label>
                <select
                  id="bloodType"
                  className="input_text"
                  {...register("bloodType", { required: true })}
                >
                  <option value="A Positivo">A+</option>
                  <option value="A Negativo">A-</option>
                  <option value="B Positivo">B+</option>
                  <option value="B Negativo">B-</option>
                  <option value="AB Positivo">AB+</option>
                  <option value="AB Negativo">AB-</option>
                  <option value="O Positivo">O+</option>
                  <option value="O Negativo">O-</option>
                </select>
                {errors.bloodType && <p className="error-message">El tipo de sangre es requerido</p>}
              </div>
              <div>
                <label htmlFor="maritalStatus">Estado civil</label>
                <select
                  id="maritalStatus"
                  className="input_text"
                  {...register("maritalStatus", { required: true })}
                >
                  <option value="single">Soltero</option>
                  <option value="married">Casado</option>
                  <option value="widow">Viudo</option>
                  <option value="divorced">Divorciado</option>
                </select>
                {errors.maritalStatus && <p className="error-message">El estado civil es requerido</p>}
              </div>
              <div>
                <label htmlFor="children">Identificador</label>
                <input
                  type="number"
                  id="children"
                  className="input_text"
                  min={0}
                  max={10}
                  defaultValue={0}
                  {...register("children", { required: true })}
                />
                {errors.children && <p className="error-message">El identificador es requerido</p>}
              </div>
              <div>
                <label htmlFor="studyGrade">Ultimo grado de estudios</label>
                <select
                  id="studyGrade"
                  className="input_text"
                  {...register("studyGrade", { required: true })}
                >
                  <option value="primary">Primaria</option>
                  <option value="secondary">Secundaria</option>
                  <option value="highSchool">Bachillerato</option>
                  <option value="university">Licenciatura</option>
                  <option value="Masters">Maestría</option>
                  <option value="Doctorate">Doctorado</option>
                </select>
                {errors.studyGrade && (
                  <p className="error-message">El ultimo grado de estudios es requerido</p>
                )}
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
              {...register("contactInfo.email", { required: true })}
            />
            {errors.contactInfo?.email && <p className="error-message">El email es requerido</p>}
            <label htmlFor="phoneNumber">Numero de telefono</label>
            <input
              type="text"
              id="phoneNumber"
              className="input_text"
              {...register("contactInfo.phoneNumber", { required: true })}
            />
            {errors.contactInfo?.phoneNumber && <p className="error-message">El numero de telefono es requerido</p>}
          </div>
          <h2>Datos de vivienda</h2>
          <h2>Datos de trabajo</h2>
          <h2>Contacto de emergencia</h2>
        </div>
        <button type="submit" className="p-2 bg-green-500 rounded-md">
          Crear Empleado
        </button>
      </form>
      </FormProvider>
    </div>
  );
};
