using smart_booking.BLL.DataTransferModels;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public static class ModelFactory
    {

        public static WorkingHour changeFromDTM(WorkingHourDTM workingHourDtm)
        {
            WorkingHour workingHour = new WorkingHour();
            workingHour.EmployeeId = workingHourDtm.EmployeeId;
            workingHour.MondayStart = workingHourDtm.MondayStart;
            workingHour.MondayStop = workingHourDtm.MondayStop;
            workingHour.TuesdayStart = workingHourDtm.TuesdayStart;
            workingHour.TuesdayStop = workingHourDtm.TuesdayStop;
            workingHour.WednesdayStart = workingHourDtm.WednesdayStart;
            workingHour.WednesdayStop = workingHourDtm.WednesdayStop;
            workingHour.ThursdayStart = workingHourDtm.ThursdayStart;
            workingHour.ThursdayStop = workingHourDtm.ThursdayStop;
            workingHour.FridayStart = workingHourDtm.FridayStart;
            workingHour.FridayStop = workingHourDtm.FridayStop;
            workingHour.SaturdayStart = workingHourDtm.SaturdayStart;
            workingHour.SaturdayStop = workingHourDtm.SaturdayStop;
            workingHour.SundayStart = workingHourDtm.SundayStart;
            workingHour.SundayStop = workingHourDtm.SundayStop;

            workingHour.Employee = workingHourDtm.Employee == null ? null : changeFromDTM(workingHourDtm.Employee);
            return workingHour;
        }

        public static Employee changeFromDTM(EmployeeDTM employeeDtm)
        {
            Employee employee = new Employee();
            employee.Id = employeeDtm.Id;
            employee.Business = changeFromDTM(employeeDtm.Business);
            employee.BusinessId = employeeDtm.Business.Id;
            employee.User = changeFromDTM(employeeDtm.User);
            employee.UserId = employeeDtm.User.Id;
            employee.IsOwner = employeeDtm.IsOwner;

            if(employeeDtm.CalendarSetting != null)
            {
                CalendarSetting cset = new CalendarSetting();
                cset = changeFromDTM(employeeDtm.CalendarSetting);
                employee.CalendarSetting = cset;
            }
            if(employeeDtm.CustomerNotification != null)
            {
                CustomerNotification cNotice = new CustomerNotification();
                cNotice = changeFromDTM(employeeDtm.CustomerNotification);
                employee.CustomerNotification = cNotice;
            }
            if(employeeDtm.TeamNotification != null)
            {
                TeamNotification tNotice = new TeamNotification();
                tNotice = changeFromDTM(employeeDtm.TeamNotification);
                employee.TeamNotification = tNotice;
            }
            if(employeeDtm.Permission != null)
            {
                Permission permission = new Permission();
                permission = changeFromDTM(employeeDtm.Permission);
                employee.Permission = permission;
            }
            if(employeeDtm.WorkingHour != null)
            {
                WorkingHour wHour = new WorkingHour();
                wHour = changeFromDTM(employeeDtm.WorkingHour);
                employee.WorkingHour = wHour;
            }
            
            return employee;
        }

        public static Business changeFromDTM(BusinessDTM businessDtm)
        {
            Business business = new Business();
            business.Id = businessDtm.Id;
            business.Name = businessDtm.Name;
            business.Phone = businessDtm.Phone;
            business.Logo = businessDtm.Logo;
            business.Webpage = businessDtm.Webpage;
            business.Address = businessDtm.Address;
            business.City = businessDtm.City;
            business.State = businessDtm.State;
            business.ZipCode = businessDtm.ZipCode;
            business.RegistrationNumber = businessDtm.RegistrationNumber;
            business.Country = businessDtm.Country == null ? null : changeFromDTM(businessDtm.Country);
            business.Currency = businessDtm.Currency == null ? null : changeFromDTM(businessDtm.Currency);
            business.Time_zone = businessDtm.Time_zone == null ? null : changeFromDTM(businessDtm.Time_zone);
            business.Booking = businessDtm.Booking == null ? null : changeFromDTM(businessDtm.Booking);
            return business;
        }

        public static Country changeFromDTM(CountryDTM countryDtm)
        {
            Country country = new Country
            {
                Id = countryDtm.Id,
                Code = countryDtm.Code,
                Name = countryDtm.Name,
                Native = countryDtm.Native,
                PhonePrefix = countryDtm.PhonePrefix,
                Capital = countryDtm.Capital,
                Currency_ = countryDtm.Currency_,
                Emoji = countryDtm.Emoji,
                EmojiU = countryDtm.EmojiU
            };
            return country;
        }
        public static Currency changeFromDTM(CurrencyDTM currencyDtm)
        {
            Currency currency = new Currency();
            currency.Id = currencyDtm.Id;
            currency.Name = currencyDtm.Name;
            return currency;
        }

        public static Time_zone changeFromDTM(Time_zoneDTM time_zoneDtm)
        {
            Time_zone zone = new Time_zone
            {
                Id = time_zoneDtm.Id,
                Zone = time_zoneDtm.Zone,
                CountryCode = time_zoneDtm.CountryCode,
                UTC_Jan_1_2020 = time_zoneDtm.UTC_Jan_1_2020,
                DST_Jul_1_2020 = time_zoneDtm.DST_Jul_1_2020
            };
            return zone;
        }

        public static Booking changeFromDTM(BookingDTM bookingDtm)
        {
            Booking booking = new Booking();
            booking.BusinessId = bookingDtm.BusinessId;
            booking.WebpageLink = bookingDtm.WebpageLink;
            booking.IsEntityLogoRemoved = bookingDtm.IsEntityLogoRemoved;
            booking.IsMemberSelecting = bookingDtm.IsMemberSelecting;
            booking.SlotDuration = bookingDtm.SlotDuration;
            booking.PageLanguageId = bookingDtm.PageLanguageId;
            booking.BannerPicture = bookingDtm.BannerPicture;
            booking.SklypeLink = bookingDtm.SklypeLink;
            booking.FacebookLink = bookingDtm.FacebookLink;
            booking.TwitterLink = bookingDtm.TwitterLink;
            booking.InstagramkLink = bookingDtm.InstagramkLink;
            booking.YoutubeLink = bookingDtm.YoutubeLink;
            booking.PageOverview = bookingDtm.PageOverview;
            booking.IsContactsAvailable = bookingDtm.IsContactsAvailable;
            booking.IsServicesAvailable = bookingDtm.IsServicesAvailable;
            booking.IsPriceAvailable = bookingDtm.IsPriceAvailable;
            booking.IsDurationAvailable = bookingDtm.IsDurationAvailable;
            booking.IsDescriptionAvailable = bookingDtm.IsDescriptionAvailable;

            if (bookingDtm.Business != null)
            {
                Business business = new Business();
                business.Id = bookingDtm.Business.Id;
                business.Name = bookingDtm.Business.Name;
                business.Phone = bookingDtm.Business.Phone;
                business.Logo = bookingDtm.Business.Logo;
                business.Webpage = bookingDtm.Business.Webpage;
                business.Address = bookingDtm.Business.Address;
                business.City = bookingDtm.Business.City;
                business.State = bookingDtm.Business.State;
                business.ZipCode = bookingDtm.Business.ZipCode;
                business.RegistrationNumber = bookingDtm.Business.RegistrationNumber;
                business.Country = null;
                business.Currency = null;
                business.Time_zone = null;
                business.Booking = null;
            }
                return booking;
        }

        public static User changeFromDTM(UserDTM userDtm)
        {
            User user = new User();
            user.Id = userDtm.Id;
            user.Email = userDtm.Email;
            user.FirstName = userDtm.FirstName;
            user.SecondName = userDtm.SecondName;
            user.PhoneMobile = userDtm.PhoneMobile;
            user.PhoneOffice = userDtm.PhoneOffice;
            user.UserPicture = userDtm.UserPicture;
            user.Address = userDtm.Address;
            user.City = userDtm.City;
            user.State = userDtm.State;
            user.ZipCode = userDtm.ZipCode;
            user.PlanId = userDtm.PlanId;
            user.IsPaymentOverdue = userDtm.IsPaymentOverdue;
            user.IsMale = userDtm.IsMale;
            user.Birthdate = userDtm.Birthdate;

            if (userDtm.Country != null)
            {
                Country country = new Country();
                country.Id = userDtm.Country.Id;
                country.Code = userDtm.Country.Code;
                country.Name = userDtm.Country.Name;
                country.Native = userDtm.Country.Native;
                country.PhonePrefix = userDtm.Country.PhonePrefix;
                country.Capital = userDtm.Country.Capital;
                country.Currency_ = userDtm.Country.Currency_;
                country.Emoji = userDtm.Country.Emoji;
                country.EmojiU = userDtm.Country.EmojiU;
                user.Country = country;
            }

            if (userDtm.Time_zone != null)
            {
                Time_zone tz = new Time_zone();
                tz.Id = userDtm.Time_zone.Id;
                tz.Zone = userDtm.Time_zone.Zone;
                tz.CountryCode = userDtm.Time_zone.CountryCode;
                tz.UTC_Jan_1_2020 = userDtm.Time_zone.UTC_Jan_1_2020;
                tz.DST_Jul_1_2020 = userDtm.Time_zone.DST_Jul_1_2020;
                user.Time_zone = tz;
            }
            return user;
        }

        public static CalendarSetting changeFromDTM(CalendarSettingDTM cSettingDtm)
        {
            CalendarSetting cSetting = new CalendarSetting();
            cSetting.EmployeeId = cSettingDtm.EmployeeId;
            cSetting.View = cSettingDtm.View;
            cSetting.FirstHour = cSettingDtm.FirstHour;
            cSetting.WorkingDayDuration = cSettingDtm.WorkingDayDuration;
            cSetting.SlotDuration = cSettingDtm.SlotDuration;

            if (cSettingDtm.Employee != null)
            cSetting.Employee = changeFromDTM(cSettingDtm.Employee);

            return cSetting;
        }

        public static CustomerNotification changeFromDTM(CustomerNotificationDTM cNoticeDtm)
        {
            CustomerNotification customerNotification = new CustomerNotification();
            customerNotification.EmployeeId = cNoticeDtm.EmployeeId;
            customerNotification.AfterBooked = cNoticeDtm.AfterBooked;
            customerNotification.AfterRescheduled = cNoticeDtm.AfterRescheduled;
            customerNotification.AfterCancelled = cNoticeDtm.AfterCancelled;

            if (cNoticeDtm.Employee != null)
            customerNotification.Employee = changeFromDTM(cNoticeDtm.Employee);

            return customerNotification;
        }

        public static TeamNotification changeFromDTM(TeamNotificationDTM tNoticeDtm)
        {
            TeamNotification tNotification = new TeamNotification();
            tNotification.EmployeeId = tNoticeDtm.EmployeeId;
            tNotification.AfterBooked = tNoticeDtm.AfterBooked;
            tNotification.AfterRescheduled = tNoticeDtm.AfterRescheduled;
            tNotification.Collegue = tNoticeDtm.Collegue;
            tNotification.CollegueAndOwner = tNoticeDtm.CollegueAndOwner;
            tNotification.Owner = tNoticeDtm.Owner;

            if (tNoticeDtm.Employee != null)
                tNotification.Employee = changeFromDTM(tNoticeDtm.Employee);
            return tNotification;
        }

        public static Permission changeFromDTM(PermissionDTM permissionDtm)
        {
            Permission permission = new Permission();
            permission.EmployeeId = permissionDtm.EmployeeId;
            permission.IsSummary = permissionDtm.IsSummary;
            permission.IsOthersCalendar = permissionDtm.IsOthersCalendar;
            permission.IsClients = permissionDtm.IsClients;
            permission.IsServices = permissionDtm.IsServices;
            permission.IsReports = permissionDtm.IsReports;

            if (permissionDtm.Employee != null)
                permission.Employee = changeFromDTM(permissionDtm.Employee);
            return permission;
        }
        public static CalendarSettingDTM changeToDTM(CalendarSetting setting)
        {
            CalendarSettingDTM cSetting = new CalendarSettingDTM();
            cSetting.EmployeeId = setting.EmployeeId;
            cSetting.View = setting.View;
            cSetting.FirstHour = setting.FirstHour;
            cSetting.WorkingDayDuration = setting.WorkingDayDuration;
            cSetting.SlotDuration = setting.SlotDuration;
            return cSetting;
        }

        public static CustomerNotificationDTM changeToDTM(CustomerNotification cNotification)
        {
            CustomerNotificationDTM customerNotificationDTM = new CustomerNotificationDTM();
            customerNotificationDTM.EmployeeId = cNotification.EmployeeId;
            customerNotificationDTM.AfterBooked = cNotification.AfterBooked;
            customerNotificationDTM.AfterRescheduled = cNotification.AfterRescheduled;
            customerNotificationDTM.AfterCancelled = cNotification.AfterCancelled;
            return customerNotificationDTM;
        }

        public static TeamNotificationDTM changeToDTM(TeamNotification tNotification)
        {
            TeamNotificationDTM tNotificationDTM = new TeamNotificationDTM();
            tNotificationDTM.EmployeeId = tNotification.EmployeeId;
            tNotificationDTM.AfterBooked = tNotification.AfterBooked;
            tNotificationDTM.AfterRescheduled = tNotification.AfterRescheduled;
            tNotificationDTM.Collegue = tNotification.Collegue;
            tNotificationDTM.CollegueAndOwner = tNotification.CollegueAndOwner;
            tNotificationDTM.Owner = tNotification.Owner;
            return tNotificationDTM;
        }

        public static PermissionDTM changeToDTM(Permission permission)
        {
            PermissionDTM permissionDtm = new PermissionDTM();
            permissionDtm.EmployeeId = permission.EmployeeId;
            permissionDtm.IsSummary = permission.IsSummary;
            permissionDtm.IsOthersCalendar = permission.IsOthersCalendar;
            permissionDtm.IsClients = permission.IsClients;
            permissionDtm.IsServices = permission.IsServices;
            permissionDtm.IsReports = permission.IsReports;
            return permissionDtm;
        }

        public static WorkingHourDTM changeToDTM(WorkingHour workingHour)
        {
            WorkingHourDTM workingHourDTM = new WorkingHourDTM();
            workingHourDTM.EmployeeId = workingHour.EmployeeId;
            workingHourDTM.MondayStart = workingHour.MondayStart;
            workingHourDTM.MondayStop = workingHour.MondayStop;
            workingHourDTM.TuesdayStart = workingHour.TuesdayStart;
            workingHourDTM.TuesdayStop = workingHour.TuesdayStop;
            workingHourDTM.WednesdayStart = workingHour.WednesdayStart;
            workingHourDTM.WednesdayStop = workingHour.WednesdayStop;
            workingHourDTM.ThursdayStart = workingHour.ThursdayStart;
            workingHourDTM.ThursdayStop = workingHour.ThursdayStop;
            workingHourDTM.FridayStart = workingHour.FridayStart;
            workingHourDTM.FridayStop = workingHour.FridayStop;
            workingHourDTM.SaturdayStart = workingHour.SaturdayStart;
            workingHourDTM.SaturdayStop = workingHour.SaturdayStop;
            workingHourDTM.SundayStart = workingHour.SundayStart;
            workingHourDTM.SundayStop = workingHour.SundayStop;

            return workingHourDTM;
        }

        public static WorkingBreakDTM changeToDTM(WorkingBreak workingBreak)
        {
            WorkingBreakDTM workingBreakDTM = new WorkingBreakDTM();
            workingBreakDTM.Id = workingBreak.Id;
            workingBreakDTM.WeekDay = workingBreak.WeekDay;
            workingBreakDTM.BreakStart = workingBreak.BreakStart;
            workingBreakDTM.BreakStop = workingBreak.BreakStop;

            return workingBreakDTM;
        }

        public static SlotDTM changeToDTM(Slot slot)
        {
            SlotDTM slotDtm = new SlotDTM();
            slotDtm.Id = slot.Id;
            slotDtm.SlotDateTime = slot.SlotDateTime;
            slotDtm.Duration = slot.Duration;
            slotDtm.IsPadding = slot.IsPadding;
            slotDtm.PaddingAfter = slot.PaddingAfter;
            slotDtm.Reiteration = slot.Reiteration;
            slotDtm.Price = slot.Price;
            slotDtm.Note = slot.Note;
            slotDtm.Status = slot.Status;
            slotDtm.IsTimeBlock = slot.IsTimeBlock;
            slotDtm.IsReminderNeeded = slot.IsReminderNeeded;
            slotDtm.ReminderInterval = slot.ReminderInterval;

            slotDtm.EmployeeId = slot.EmployeeId;
            slotDtm.ResponsibleId = slot.ResponsibleId;
            slotDtm.CountryId = slot.CountryId;
            slotDtm.ServiceId = slot.ServiceId;
            return slotDtm;
        }

        public static UserDTM changeToDTM(User user)
        {
            UserDTM userDtm = new UserDTM();
            userDtm.Id = user.Id;
            userDtm.Email = user.Email;
            userDtm.FirstName = user.FirstName;
            userDtm.SecondName = user.SecondName;
            userDtm.PhoneMobile = user.PhoneMobile;
            userDtm.PhoneOffice = user.PhoneOffice;
            userDtm.UserPicture = user.UserPicture;
            userDtm.Address = user.Address;
            userDtm.City = user.City;
            userDtm.State = user.State;
            userDtm.ZipCode = user.ZipCode;
            userDtm.PlanId = user.PlanId;
            userDtm.IsPaymentOverdue = user.IsPaymentOverdue;
            userDtm.IsMale = user.IsMale;
            userDtm.Birthdate = user.Birthdate;

            if (user.Country != null)
            {
                CountryDTM country = new CountryDTM();
                country.Id = user.Country.Id;
                country.Code = user.Country.Code;
                country.Name = user.Country.Name;
                country.Native = user.Country.Native;
                country.PhonePrefix = user.Country.PhonePrefix;
                country.Capital = user.Country.Capital;
                country.Currency_ = user.Country.Currency_;
                country.Emoji = user.Country.Emoji;
                country.EmojiU = user.Country.EmojiU;
                userDtm.Country = country;
            }
            
            if (user.Time_zone != null)
            {
                Time_zoneDTM tz = new Time_zoneDTM();
                tz.Id = user.Time_zone.Id;
                tz.Zone = user.Time_zone.Zone;
                tz.CountryCode = user.Time_zone.CountryCode;
                tz.UTC_Jan_1_2020 = user.Time_zone.UTC_Jan_1_2020;
                tz.DST_Jul_1_2020 = user.Time_zone.DST_Jul_1_2020;
                userDtm.Time_zone = tz;
            }
            return userDtm;
        }

        public static BusinessDTM changeToDTM(Business business)
        {
            BusinessDTM bDtm = new BusinessDTM();
            bDtm.Id = business.Id;
            bDtm.Name = business.Name;
            bDtm.Phone = business.Phone;
            bDtm.Logo = business.Logo;
            bDtm.Webpage = business.Webpage;
            bDtm.Address = business.Address;
            bDtm.City = business.City;
            bDtm.State = business.State;
            bDtm.ZipCode = business.ZipCode;
            bDtm.RegistrationNumber = business.RegistrationNumber;

            if (business.Country != null)
            {
                CountryDTM country = new CountryDTM();
                country.Id = business.Country.Id;
                country.Code = business.Country.Code;
                country.Name = business.Country.Name;
                country.Native = business.Country.Native;
                country.PhonePrefix = business.Country.PhonePrefix;
                country.Capital = business.Country.Capital;
                country.Currency_ = business.Country.Currency_;
                country.Emoji = business.Country.Emoji;
                country.EmojiU = business.Country.EmojiU;
                bDtm.Country = country;
                bDtm.CountryId = business.Country.Id;
            }
            if (business.Currency != null)
            {
                CurrencyDTM currency = new CurrencyDTM();
                currency.Id = business.Currency.Id;
                currency.Name = business.Currency.Name;
                bDtm.Currency = currency;
                bDtm.CurrencyId = business.Currency.Id;
            }
            if (business.Time_zone != null)
            {
                Time_zoneDTM tz = new Time_zoneDTM();
                tz.Id = business.Time_zone.Id;
                tz.Zone = business.Time_zone.Zone;
                tz.CountryCode = business.Time_zone.CountryCode;
                tz.UTC_Jan_1_2020 = business.Time_zone.UTC_Jan_1_2020;
                tz.DST_Jul_1_2020 = business.Time_zone.DST_Jul_1_2020;
                bDtm.Time_zone = tz;
                bDtm.Time_zoneId = business.Time_zone.Id;
            }
            return bDtm;
        }

        public static EmployeeDTM changeToDTM(Employee employee)
        {
            EmployeeDTM employeeDtm = new EmployeeDTM();
            employeeDtm.Id = employee.Id;
            if (employee.Business != null)
            {
                employeeDtm.Business = changeToDTM(employee.Business);
                employeeDtm.BusinessId = employee.Business.Id;
            }
            if (employee.User != null)
            {
                employeeDtm.User = changeToDTM(employee.User);
                employeeDtm.UserId = employee.User.Id;
            }
            employeeDtm.IsOwner = employee.IsOwner;

            if(employee.CalendarSetting != null)
            {
                employeeDtm.CalendarSetting = changeToDTM(employee.CalendarSetting);
            }

            if(employee.CustomerNotification != null)
            {
                employeeDtm.CustomerNotification = changeToDTM(employee.CustomerNotification);
            }
            if (employee.TeamNotification != null)
            {
                employeeDtm.TeamNotification = changeToDTM(employee.TeamNotification);
            }
            if (employee.Permission != null)
            {
                employeeDtm.Permission = changeToDTM(employee.Permission);
            }
            if (employee.WorkingHour != null)
            {
                employeeDtm.WorkingHour = changeToDTM(employee.WorkingHour);
            }
            //if (employee.Slot != null)
            //{
            //    employeeDtm.Slot = changeToDTM(employee.Slot);
            //}

            return employeeDtm;
        }

        public static BookingDTM changeToDTM(Booking booking)
        {
            BookingDTM bDtm = new BookingDTM();
            bDtm.BusinessId = booking.BusinessId;
            bDtm.WebpageLink = booking.WebpageLink;
            bDtm.IsEntityLogoRemoved = booking.IsEntityLogoRemoved;
            bDtm.IsMemberSelecting = booking.IsMemberSelecting;
            bDtm.SlotDuration = booking.SlotDuration;
            bDtm.PageLanguageId = booking.PageLanguageId;
            bDtm.BannerPicture = booking.BannerPicture;
            bDtm.SklypeLink = booking.SklypeLink;
            bDtm.FacebookLink = booking.FacebookLink;
            bDtm.TwitterLink = booking.TwitterLink;
            bDtm.InstagramkLink = booking.InstagramkLink;
            bDtm.YoutubeLink = booking.YoutubeLink;
            bDtm.PageOverview = booking.PageOverview;
            bDtm.IsContactsAvailable = booking.IsContactsAvailable;
            bDtm.IsServicesAvailable = booking.IsServicesAvailable;
            bDtm.IsPriceAvailable = booking.IsPriceAvailable;
            bDtm.IsDurationAvailable = booking.IsDurationAvailable;
            bDtm.IsDescriptionAvailable = booking.IsDescriptionAvailable;

            if (booking.Business != null)
            {
                BusinessDTM businessDtm = new BusinessDTM();
                businessDtm.Id = booking.Business.Id;
                businessDtm.Name = booking.Business.Name;
                businessDtm.Phone = booking.Business.Phone;
                businessDtm.Logo = booking.Business.Logo;
                businessDtm.Webpage = booking.Business.Webpage;
                businessDtm.Address = booking.Business.Address;
                businessDtm.City = booking.Business.City;
                businessDtm.State = booking.Business.State;
                businessDtm.ZipCode = booking.Business.ZipCode;
                businessDtm.RegistrationNumber = booking.Business.RegistrationNumber;
                if(booking.Business.Country != null)
                    businessDtm.Country = changeToDTM(booking.Business.Country);
                if (booking.Business.Currency != null)
                    businessDtm.Currency = changeToDTM(booking.Business.Currency);
                if (booking.Business.Country != null)
                    businessDtm.Time_zone = changeToDTM(booking.Business.Time_zone);
                //if (booking.Business.Booking != null)
                //    businessDtm.Booking = changeToDTM(booking.Business.Booking);
                
                bDtm.Business = businessDtm;
            }

            return bDtm;
        }

        public static CountryDTM changeToDTM(Country country)
        {
            CountryDTM countryDtm = new CountryDTM
            {
                Id = country.Id,
                Code = country.Code,
                Name = country.Name,
                Native = country.Native,
                PhonePrefix = country.PhonePrefix,
                Capital = country.Capital,
                Currency_ = country.Currency_,
                Emoji = country.Emoji,
                EmojiU = country.EmojiU
            };
            return countryDtm;
        }

        public static CurrencyDTM changeToDTM(Currency currency)
        {
            CurrencyDTM currencyDtm = new CurrencyDTM
            {
                Id = currency.Id,
                Name = currency.Name,
               
            };
            return currencyDtm;
        }

        public static Time_zoneDTM changeToDTM(Time_zone time_zone)
        {
            Time_zoneDTM currencyDtm = new Time_zoneDTM
            {
                Id = time_zone.Id,
                Zone = time_zone.Zone,
                CountryCode = time_zone.CountryCode,
                UTC_Jan_1_2020 = time_zone.UTC_Jan_1_2020,
                DST_Jul_1_2020 = time_zone.DST_Jul_1_2020
            };
            return currencyDtm;
        }

        public static ServiceDTM changeToDTM(Service service)
        {
            ServiceDTM serviceDtm = new ServiceDTM();
            serviceDtm.Id = service.Id;
            serviceDtm.Name = service.Name;
            serviceDtm.Description = service.Description;
            serviceDtm.Price = service.Price;
            serviceDtm.Duration = service.Duration;
            serviceDtm.PaddingAfter = service.PaddingAfter;
            serviceDtm.Picture = service.Picture;
                   
            serviceDtm.ServiceCategory = service.ServiceCategory == null ? null : changeToDTM(service.ServiceCategory);

            return serviceDtm;
        }

        public static ServiceCategoryDTM changeToDTM(ServiceCategory sCategory)
        {
            ServiceCategoryDTM sCategoryDtm = new ServiceCategoryDTM();
            sCategoryDtm.Id = sCategory.Id;
            sCategoryDtm.Name = sCategory.Name;
            sCategoryDtm.BusinessId = sCategory.BusinessId;

            if (sCategory.Business != null)
                sCategoryDtm.Business = changeToDTM(sCategory.Business);

            return sCategoryDtm;
        }

        public static ServiceCategory changeFromDTM(ServiceCategoryDTM sCategoryDtm)
        {
            ServiceCategory sCategory = new ServiceCategory();
            sCategory.Id = sCategoryDtm.Id;
            sCategory.Name = sCategoryDtm.Name;
            sCategory.BusinessId = sCategoryDtm.BusinessId;

            if (sCategoryDtm.Business != null)
                sCategory.Business = changeFromDTM(sCategoryDtm.Business);

            return sCategory;
        }

        public static ClientDTM changeToDTM(Client client)
        {
            ClientDTM clientDtm = new ClientDTM();
            clientDtm.Id = client.Id;
            clientDtm.FirstName = client.FirstName;
            clientDtm.SecondName = client.SecondName;
            clientDtm.ClientCompanyName = client.ClientCompanyName;
            clientDtm.Email = client.Email;
            clientDtm.MobilePhone = client.MobilePhone;
            clientDtm.OfficePhone = client.OfficePhone;
            clientDtm.Address = client.Address;
            clientDtm.City = client.City;
            clientDtm.State = client.State;
            clientDtm.Zip_Code = client.Zip_Code;
            clientDtm.BirthDay = client.BirthDay;
            clientDtm.Image = client.Image;
            clientDtm.IsMale = client.IsMale;
            clientDtm.Note = client.Note;
            clientDtm.BusinessId = client.BusinessId;

            if (client.Business != null)
                clientDtm.Business = changeToDTM(client.Business);

            return clientDtm;
        }

        public static Client changeFromDTM(ClientDTM clientDtm)
        {
            Client client = new Client();
            client.Id = clientDtm.Id;
            client.FirstName = clientDtm.FirstName;
            client.SecondName = clientDtm.SecondName;
            client.ClientCompanyName = clientDtm.ClientCompanyName;
            client.Email = clientDtm.Email;
            client.MobilePhone = clientDtm.MobilePhone;
            client.OfficePhone = clientDtm.OfficePhone;
            client.Address = clientDtm.Address;
            client.City = clientDtm.City;
            client.State = clientDtm.State;
            client.Zip_Code = clientDtm.Zip_Code;
            client.BirthDay = clientDtm.BirthDay;
            client.Image = clientDtm.Image;
            client.IsMale = clientDtm.IsMale;
            client.Note = clientDtm.Note;
            client.BusinessId = clientDtm.BusinessId;

            if (clientDtm.Business != null)
            client.Business = changeFromDTM(clientDtm.Business);

            return client;
        }

    }
}
