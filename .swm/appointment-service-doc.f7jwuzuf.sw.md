---
title: Appointment service doc
---
# Introduction

This document will walk you through the implementation of the Appointment Service in the DentalManagerAPI. The Appointment Service is a crucial part of the system, as it handles all the operations related to appointments, such as creating, updating, deleting, and retrieving appointments.

We will cover:

1. Why we use the Unit of Work and Repository patterns.


1. The role of the AutoMapper library in our service.


1. How we handle different types of appointment retrievals.


1. The process of creating, updating, and deleting appointments.

# Unit of Work and Repository Patterns

<SwmSnippet path="/DentalManagerAPI/Services/AppointmentService.cs" line="9">

---

In the Appointment Service, we use the Unit of Work and Repository patterns. These patterns are used to abstract the underlying data access layer, which provides a simple API for retrieving and managing the application's data. This way, we can change the data source or the way we access data without affecting the rest of the application.

```c#
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public FullAppointmentDTO GetById(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);
            return _mapper.Map<FullAppointmentDTO>(appointment);
        }

        public List<FullAppointmentDTO> GetByWorkerId(int id)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByWorkerId(id);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }

        public List<FullAppointmentDTO> GetByPatientId(int id)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByPatientId(id);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }
        public List<FullAppointmentDTO> GetByPhoneNumber(string phoneNumber)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByPhoneNumber(phoneNumber);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }

        public List<ShortAppointmentDTO> GetAll()
        {
            var appointments = _unitOfWork.AppointmentRepository.GetAll();
            return _mapper.Map<List<Appointment>, List<ShortAppointmentDTO>>(appointments.ToList());          
        }

        public int Create(CreateAppointmentDTO appointment)
        {
            var mappedAppointment = _mapper.Map<CreateAppointmentDTO, Appointment>(appointment);

            var newAppointment = _unitOfWork.AppointmentRepository.Add(mappedAppointment);
            _unitOfWork.Save();

            return newAppointment.Id;
        }

        

        public EditAppointmentDTO Update(EditAppointmentDTO appointment)
        {
            var updateAppointment = _mapper.Map<Appointment>(appointment);
            var updatedAppointment = _unitOfWork.AppointmentRepository.Edit(updateAppointment);
            

            _unitOfWork.Save();

            return _mapper.Map<EditAppointmentDTO>(updatedAppointment);       
        }

        public void Delete(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);
            if (appointment != null)
            {
                _unitOfWork.AppointmentRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
```

---

</SwmSnippet>

# AutoMapper Library

<SwmSnippet path="/DentalManagerAPI/Services/AppointmentService.cs" line="9">

---

We use the AutoMapper library to map between our data entities and DTOs (Data Transfer Objects). This library simplifies the code and avoids repetitive mapping logic. It's especially useful when dealing with complex objects that have many properties.

```c#
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public FullAppointmentDTO GetById(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);
            return _mapper.Map<FullAppointmentDTO>(appointment);
        }

        public List<FullAppointmentDTO> GetByWorkerId(int id)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByWorkerId(id);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }

        public List<FullAppointmentDTO> GetByPatientId(int id)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByPatientId(id);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }
        public List<FullAppointmentDTO> GetByPhoneNumber(string phoneNumber)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByPhoneNumber(phoneNumber);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }

        public List<ShortAppointmentDTO> GetAll()
        {
            var appointments = _unitOfWork.AppointmentRepository.GetAll();
            return _mapper.Map<List<Appointment>, List<ShortAppointmentDTO>>(appointments.ToList());          
        }

        public int Create(CreateAppointmentDTO appointment)
        {
            var mappedAppointment = _mapper.Map<CreateAppointmentDTO, Appointment>(appointment);

            var newAppointment = _unitOfWork.AppointmentRepository.Add(mappedAppointment);
            _unitOfWork.Save();

            return newAppointment.Id;
        }

        

        public EditAppointmentDTO Update(EditAppointmentDTO appointment)
        {
            var updateAppointment = _mapper.Map<Appointment>(appointment);
            var updatedAppointment = _unitOfWork.AppointmentRepository.Edit(updateAppointment);
            

            _unitOfWork.Save();

            return _mapper.Map<EditAppointmentDTO>(updatedAppointment);       
        }

        public void Delete(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);
            if (appointment != null)
            {
                _unitOfWork.AppointmentRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
```

---

</SwmSnippet>

# Appointment Retrievals

<SwmSnippet path="/DentalManagerAPI/Services/AppointmentService.cs" line="9">

---

The Appointment Service provides several methods to retrieve appointments. We can get an appointment by its ID, by the worker's ID, by the patient's ID, or by the patient's phone number. We also have a method to get all appointments. These methods give us flexibility in how we retrieve appointments based on different requirements.

```c#
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public FullAppointmentDTO GetById(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);
            return _mapper.Map<FullAppointmentDTO>(appointment);
        }

        public List<FullAppointmentDTO> GetByWorkerId(int id)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByWorkerId(id);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }

        public List<FullAppointmentDTO> GetByPatientId(int id)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByPatientId(id);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }
        public List<FullAppointmentDTO> GetByPhoneNumber(string phoneNumber)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByPhoneNumber(phoneNumber);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }

        public List<ShortAppointmentDTO> GetAll()
        {
            var appointments = _unitOfWork.AppointmentRepository.GetAll();
            return _mapper.Map<List<Appointment>, List<ShortAppointmentDTO>>(appointments.ToList());          
        }

        public int Create(CreateAppointmentDTO appointment)
        {
            var mappedAppointment = _mapper.Map<CreateAppointmentDTO, Appointment>(appointment);

            var newAppointment = _unitOfWork.AppointmentRepository.Add(mappedAppointment);
            _unitOfWork.Save();

            return newAppointment.Id;
        }

        

        public EditAppointmentDTO Update(EditAppointmentDTO appointment)
        {
            var updateAppointment = _mapper.Map<Appointment>(appointment);
            var updatedAppointment = _unitOfWork.AppointmentRepository.Edit(updateAppointment);
            

            _unitOfWork.Save();

            return _mapper.Map<EditAppointmentDTO>(updatedAppointment);       
        }

        public void Delete(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);
            if (appointment != null)
            {
                _unitOfWork.AppointmentRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
```

---

</SwmSnippet>

# Creating, Updating, and Deleting Appointments

<SwmSnippet path="/DentalManagerAPI/Services/AppointmentService.cs" line="9">

---

The Appointment Service also handles creating, updating, and deleting appointments. When creating or updating an appointment, we map the incoming DTO to an Appointment entity, then pass it to the repository to be saved in the database. When deleting an appointment, we first check if the appointment exists before deleting it. After each operation, we call the Save method on the Unit of Work to persist the changes to the database.

```c#
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public FullAppointmentDTO GetById(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);
            return _mapper.Map<FullAppointmentDTO>(appointment);
        }

        public List<FullAppointmentDTO> GetByWorkerId(int id)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByWorkerId(id);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }

        public List<FullAppointmentDTO> GetByPatientId(int id)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByPatientId(id);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }
        public List<FullAppointmentDTO> GetByPhoneNumber(string phoneNumber)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetByPhoneNumber(phoneNumber);
            return _mapper.Map<List<Appointment>, List<FullAppointmentDTO>>(appointments.ToList());
        }

        public List<ShortAppointmentDTO> GetAll()
        {
            var appointments = _unitOfWork.AppointmentRepository.GetAll();
            return _mapper.Map<List<Appointment>, List<ShortAppointmentDTO>>(appointments.ToList());          
        }

        public int Create(CreateAppointmentDTO appointment)
        {
            var mappedAppointment = _mapper.Map<CreateAppointmentDTO, Appointment>(appointment);

            var newAppointment = _unitOfWork.AppointmentRepository.Add(mappedAppointment);
            _unitOfWork.Save();

            return newAppointment.Id;
        }

        

        public EditAppointmentDTO Update(EditAppointmentDTO appointment)
        {
            var updateAppointment = _mapper.Map<Appointment>(appointment);
            var updatedAppointment = _unitOfWork.AppointmentRepository.Edit(updateAppointment);
            

            _unitOfWork.Save();

            return _mapper.Map<EditAppointmentDTO>(updatedAppointment);       
        }

        public void Delete(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);
            if (appointment != null)
            {
                _unitOfWork.AppointmentRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
```

---

</SwmSnippet>

In conclusion, the Appointment Service is a key component of the DentalManagerAPI. It uses the Unit of Work and Repository patterns to manage data access, the AutoMapper library to map between entities and DTOs, and provides a variety of methods to retrieve and manage appointments.

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBRGVudGFsTWFuYWdlckFQSSUzQSUzQWl2YW4xOTEwMTkxMA==" repo-name="DentalManagerAPI"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
