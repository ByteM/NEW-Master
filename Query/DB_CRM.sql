USE [DB_CRM]
GO
/****** Object:  Table [dbo].[Add_Dealer]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Add_Dealer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Dealer_ID] [varchar](max) NOT NULL,
	[Dealer_Name] [varchar](max) NOT NULL,
	[Phone_No] [varchar](max) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Dealer_for_Product] [varchar](max) NOT NULL,
	[Sataus] [varchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [P_dealer_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ADD_Default_Bithday]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ADD_Default_Bithday](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text_Message] [varchar](max) NOT NULL,
	[Sataus] [varchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [P_birth_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ADD_Default_Followup]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ADD_Default_Followup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text_Message] [varchar](max) NOT NULL,
	[Sataus] [varchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [P_follow_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ADD_Default_Thank_you]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ADD_Default_Thank_you](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text_Message] [varchar](max) NOT NULL,
	[Sataus] [varchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [P_thank_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin_Login]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin_Login](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login_ID] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Change_Password] [varchar](max) NOT NULL,
	[Sataus] [varchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [P_A_login_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Final_DealerDetails]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Final_DealerDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Dealer_ID] [int] NOT NULL,
	[SalesID] [nvarchar](max) NOT NULL,
	[Domain_ID] [int] NOT NULL,
	[Product_ID] [int] NOT NULL,
	[Brand_ID] [int] NOT NULL,
	[P_Category] [int] NOT NULL,
	[Model_No_ID] [int] NOT NULL,
	[Color_ID] [int] NOT NULL,
	[ProcNetAmt] [money] NOT NULL,
	[ProcPrice] [money] NOT NULL,
	[ProcQty] [nvarchar](max) NOT NULL,
	[FinalPrice] [money] NOT NULL,
	[FinalQty] [nvarchar](max) NOT NULL,
	[SubTotal] [money] NOT NULL,
	[RoundUp] [money] NOT NULL,
	[NetAmt] [money] NOT NULL,
	[SDefault] [nvarchar](max) NOT NULL,
	[ServiceIntervalMonth] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [pk_Final_DealerID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Main_Login]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Main_Login](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login_ID] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Change_Password] [varchar](max) NOT NULL,
	[Sataus] [varchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [P_login_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pre_Procurement]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pre_Procurement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DealerID] [int] NOT NULL,
	[Domain_ID] [int] NOT NULL,
	[Product_ID] [int] NOT NULL,
	[Brand_ID] [int] NOT NULL,
	[P_Category] [int] NOT NULL,
	[Model_No_ID] [int] NOT NULL,
	[Color_ID] [int] NOT NULL,
	[Procurment_Price] [money] NOT NULL,
	[Quantity] [money] NOT NULL,
	[Total_Amount] [money] NOT NULL,
	[Net_Amount] [money] NOT NULL,
	[Round_Off] [money] NOT NULL,
	[Reg_Document] [nvarchar](max) NOT NULL,
	[Have_Insurance] [nvarchar](max) NOT NULL,
	[Warranty] [nvarchar](max) NOT NULL,
	[re_ferb_cost] [nvarchar](max) NULL,
	[Follow_up] [nvarchar](max) NOT NULL,
	[Narration] [nvarchar](max) NOT NULL,
	[PendingPreProc] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [pk_Pro_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pre_Products]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pre_Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Domain_ID] [int] NOT NULL,
	[Product_ID] [int] NOT NULL,
	[Brand_ID] [int] NOT NULL,
	[P_Category] [int] NOT NULL,
	[Model_No_ID] [int] NOT NULL,
	[Color_ID] [int] NOT NULL,
	[Narration] [nvarchar](max) NOT NULL,
	[Price] [money] NOT NULL,
	[S_Status] [nvarchar](max) NULL,
	[C_Date] [datetime] NULL,
 CONSTRAINT [pk_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockDetails]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Domain_ID] [int] NOT NULL,
	[Product_ID] [int] NOT NULL,
	[Brand_ID] [int] NOT NULL,
	[P_Category] [int] NOT NULL,
	[Model_No_ID] [int] NOT NULL,
	[Color_ID] [int] NOT NULL,
	[Products123] [nvarchar](max) NOT NULL,
	[AvilableQty] [nvarchar](max) NOT NULL,
	[SaleQty] [nvarchar](max) NOT NULL,
	[NewQty] [nvarchar](max) NOT NULL,
	[FinalPrice] [money] NULL,
	[HaveInsurance] [nvarchar](max) NOT NULL,
	[Warranty] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [pk_StockDetailsID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_Domain]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Domain](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Domain_Name] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
	[PAN_Card] [nvarchar](max) NULL,
	[Adhar_Card] [nvarchar](max) NULL,
	[Passport] [nvarchar](max) NULL,
	[Address_Proof] [nvarchar](max) NULL,
	[Seven_Twevel] [nvarchar](max) NULL,
	[Form_16] [nvarchar](max) NULL,
	[Dealer_Lisence] [nvarchar](max) NULL,
	[Other_ID_Proof] [nvarchar](max) NULL,
	[No_Documents] [nvarchar](max) NULL,
	[Cmp_ID_Proof] [nvarchar](max) NULL,
 CONSTRAINT [pk_DID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DealerEntry]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DealerEntry](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DealerEntryID] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[DealerFirstName] [nvarchar](max) NOT NULL,
	[DealerLastName] [nvarchar](max) NOT NULL,
	[DateOfBirth] [nvarchar](max) NOT NULL,
	[MobileNo] [nvarchar](max) NOT NULL,
	[PhoneNo] [nvarchar](max) NOT NULL,
	[DealerAddress] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Zip] [nvarchar](max) NOT NULL,
	[DState] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [pk_DealerEntryID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Employee]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](max) NOT NULL,
	[EmployeeFirstName] [nvarchar](max) NOT NULL,
	[EmployeeLastName] [nvarchar](max) NULL,
	[DateOfBirth] [nvarchar](max) NOT NULL,
	[MobileNo] [nvarchar](max) NOT NULL,
	[PhoneNo] [nvarchar](max) NOT NULL,
	[EmpAddress] [nvarchar](max) NOT NULL,
	[EmpCity] [nvarchar](max) NOT NULL,
	[EmpZipNo] [nvarchar](max) NOT NULL,
	[EmpState] [nvarchar](max) NOT NULL,
	[EmpCountry] [nvarchar](max) NOT NULL,
	[Designation] [nvarchar](max) NOT NULL,
	[DateOfJoining] [datetime] NOT NULL,
	[NoOfYears] [nvarchar](max) NOT NULL,
	[Years] [nvarchar](max) NOT NULL,
	[NoOfMonths] [nvarchar](max) NOT NULL,
	[Months] [nvarchar](max) NOT NULL,
	[Salary] [money] NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [pk_EmployeeID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_EmployeePhoto]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_EmployeePhoto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[PhotoPath] [nvarchar](max) NOT NULL,
	[EmpImage] [image] NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [pk_tbl_EmployeePhoto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_AddTax]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_AddTax](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tax_Type] [nvarchar](max) NOT NULL,
	[Tax_Percentage] [money] NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [pk_addtaxID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_Brand]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_Brand](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_ID] [int] NOT NULL,
	[Brand_Name] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [pk_Product_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_Color]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_Color](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Model_No_ID] [int] NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [pk_ModelNo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_Customer]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cust_ID] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Date_Of_Birth] [nvarchar](max) NOT NULL,
	[Occupation] [nvarchar](max) NOT NULL,
	[Mobile_No] [nvarchar](max) NOT NULL,
	[PhoneNo] [nvarchar](max) NOT NULL,
	[Email_ID] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[ZipNo] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[SourceOfEnquiry] [nvarchar](max) NOT NULL,
	[SourceEnquiryID] [int] NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [CId] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_CustomerBalance]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_CustomerBalance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SelectCategory] [nvarchar](max) NOT NULL,
	[SMSDate] [nvarchar](max) NOT NULL,
	[SMSMessage] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tlb_CustomerBalance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_CustomerFollowupDefaultSMS]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_CustomerFollowupDefaultSMS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SelectCategory] [nvarchar](max) NOT NULL,
	[SMSDate] [nvarchar](max) NOT NULL,
	[SMSMessage] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tlb_CustomerFollowupDefaultSMS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_DealerFollowupDefaultSMS]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_DealerFollowupDefaultSMS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SelectCategory] [nvarchar](max) NOT NULL,
	[SMSDate] [nvarchar](max) NOT NULL,
	[SMSMessage] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tlb_DealerFollowupDefaultSMS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_DefaultCustomerBirthdaySMS]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_DefaultCustomerBirthdaySMS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SelectCategory] [nvarchar](max) NOT NULL,
	[SMSDate] [nvarchar](max) NOT NULL,
	[SMSMessage] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DefaultCustomerBirthdaySMS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_FollowUp]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_FollowUp](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Followup_ID] [nvarchar](max) NOT NULL,
	[FTitle] [nvarchar](max) NOT NULL,
	[FiratName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Date_Of_Birth] [nvarchar](max) NOT NULL,
	[Mobile_No] [nvarchar](max) NOT NULL,
	[Phone_No] [nvarchar](max) NOT NULL,
	[SourceOfEnquiry] [nvarchar](max) NULL,
	[SourceEnquiryID] [int] NOT NULL,
	[Occupation] [nvarchar](max) NOT NULL,
	[AnnualRevenue] [money] NOT NULL,
	[Email_ID] [nvarchar](max) NOT NULL,
	[FaxNo] [nvarchar](max) NOT NULL,
	[Wbsite] [nvarchar](max) NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[ZipNo] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[F_Date] [nvarchar](max) NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [pk_Follow_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_FollowUpActivity]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_FollowUpActivity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FollowupID] [int] NOT NULL,
	[ASubject] [nvarchar](max) NOT NULL,
	[ADate] [nvarchar](max) NOT NULL,
	[AEmployeeID] [int] NOT NULL,
	[ANotes] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [pk_tlb_FollowUpActivity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_FollowUpCampaign]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_FollowUpCampaign](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CampaignName] [nvarchar](max) NOT NULL,
	[CampaignType] [nvarchar](max) NOT NULL,
	[StartDate] [nvarchar](max) NOT NULL,
	[EndDate] [nvarchar](max) NOT NULL,
	[ExpectedRevenue] [money] NOT NULL,
	[BudgetedCost] [money] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[ExpectedResponse] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [pk_tlb_FollowUpCampaign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_FollowUpComments]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_FollowUpComments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FollowupID] [int] NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [pk_tlb_FollowUpComments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_FollowUpProducts]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_FollowUpProducts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FollowupID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [pk_tlb_FollowUpProducts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_InsuranceDefaultSMS]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_InsuranceDefaultSMS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SelectCategory] [nvarchar](max) NOT NULL,
	[SMSDate] [nvarchar](max) NOT NULL,
	[SMSMessage] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tlb_Insurance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_Model]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_Model](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[P_Category] [int] NOT NULL,
	[Model_No] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [pk_P_Category_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_P_Category]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_P_Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Brand_ID] [int] NOT NULL,
	[Product_Category] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [pk_Brand_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_Products]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Domain_ID] [int] NOT NULL,
	[Product_Name] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [datetime] NOT NULL,
 CONSTRAINT [pk_Domain_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlb_Waranty]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tlb_Waranty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SelectCategory] [nvarchar](max) NOT NULL,
	[SMSDate] [nvarchar](max) NOT NULL,
	[SMSMessage] [nvarchar](max) NOT NULL,
	[S_Status] [nvarchar](max) NOT NULL,
	[C_Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tlb_Waranty] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Final_DealerDetails]  WITH CHECK ADD  CONSTRAINT [fk_B_Final_DealerDetailsID] FOREIGN KEY([Brand_ID])
REFERENCES [dbo].[tlb_Brand] ([ID])
GO
ALTER TABLE [dbo].[Final_DealerDetails] CHECK CONSTRAINT [fk_B_Final_DealerDetailsID]
GO
ALTER TABLE [dbo].[Final_DealerDetails]  WITH CHECK ADD  CONSTRAINT [fk_C_Final_DealerDetailsID] FOREIGN KEY([Color_ID])
REFERENCES [dbo].[tlb_Color] ([ID])
GO
ALTER TABLE [dbo].[Final_DealerDetails] CHECK CONSTRAINT [fk_C_Final_DealerDetailsID]
GO
ALTER TABLE [dbo].[Final_DealerDetails]  WITH CHECK ADD  CONSTRAINT [fk_D_Final_DealerDetailsID] FOREIGN KEY([Domain_ID])
REFERENCES [dbo].[tb_Domain] ([ID])
GO
ALTER TABLE [dbo].[Final_DealerDetails] CHECK CONSTRAINT [fk_D_Final_DealerDetailsID]
GO
ALTER TABLE [dbo].[Final_DealerDetails]  WITH CHECK ADD  CONSTRAINT [fk_D_Final_DealerEntryID] FOREIGN KEY([Dealer_ID])
REFERENCES [dbo].[tbl_DealerEntry] ([ID])
GO
ALTER TABLE [dbo].[Final_DealerDetails] CHECK CONSTRAINT [fk_D_Final_DealerEntryID]
GO
ALTER TABLE [dbo].[Final_DealerDetails]  WITH CHECK ADD  CONSTRAINT [fk_M_Final_DealerDetailsID] FOREIGN KEY([Model_No_ID])
REFERENCES [dbo].[tlb_Model] ([ID])
GO
ALTER TABLE [dbo].[Final_DealerDetails] CHECK CONSTRAINT [fk_M_Final_DealerDetailsID]
GO
ALTER TABLE [dbo].[Final_DealerDetails]  WITH CHECK ADD  CONSTRAINT [fk_P_Final_DealerDetailsID] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[tlb_Products] ([ID])
GO
ALTER TABLE [dbo].[Final_DealerDetails] CHECK CONSTRAINT [fk_P_Final_DealerDetailsID]
GO
ALTER TABLE [dbo].[Final_DealerDetails]  WITH CHECK ADD  CONSTRAINT [fk_PC_Final_DealerDetailsID] FOREIGN KEY([P_Category])
REFERENCES [dbo].[tlb_P_Category] ([ID])
GO
ALTER TABLE [dbo].[Final_DealerDetails] CHECK CONSTRAINT [fk_PC_Final_DealerDetailsID]
GO
ALTER TABLE [dbo].[Pre_Procurement]  WITH CHECK ADD  CONSTRAINT [fk_DealerEntryID] FOREIGN KEY([DealerID])
REFERENCES [dbo].[tbl_DealerEntry] ([ID])
GO
ALTER TABLE [dbo].[Pre_Procurement] CHECK CONSTRAINT [fk_DealerEntryID]
GO
ALTER TABLE [dbo].[Pre_Procurement]  WITH CHECK ADD  CONSTRAINT [fk_ProBrandID] FOREIGN KEY([Brand_ID])
REFERENCES [dbo].[tlb_Brand] ([ID])
GO
ALTER TABLE [dbo].[Pre_Procurement] CHECK CONSTRAINT [fk_ProBrandID]
GO
ALTER TABLE [dbo].[Pre_Procurement]  WITH CHECK ADD  CONSTRAINT [fk_ProColorID] FOREIGN KEY([Color_ID])
REFERENCES [dbo].[tlb_Color] ([ID])
GO
ALTER TABLE [dbo].[Pre_Procurement] CHECK CONSTRAINT [fk_ProColorID]
GO
ALTER TABLE [dbo].[Pre_Procurement]  WITH CHECK ADD  CONSTRAINT [fk_ProDomainID] FOREIGN KEY([Domain_ID])
REFERENCES [dbo].[tb_Domain] ([ID])
GO
ALTER TABLE [dbo].[Pre_Procurement] CHECK CONSTRAINT [fk_ProDomainID]
GO
ALTER TABLE [dbo].[Pre_Procurement]  WITH CHECK ADD  CONSTRAINT [fk_PromodelID] FOREIGN KEY([Model_No_ID])
REFERENCES [dbo].[tlb_Model] ([ID])
GO
ALTER TABLE [dbo].[Pre_Procurement] CHECK CONSTRAINT [fk_PromodelID]
GO
ALTER TABLE [dbo].[Pre_Procurement]  WITH CHECK ADD  CONSTRAINT [fk_ProPCategoryID] FOREIGN KEY([P_Category])
REFERENCES [dbo].[tlb_P_Category] ([ID])
GO
ALTER TABLE [dbo].[Pre_Procurement] CHECK CONSTRAINT [fk_ProPCategoryID]
GO
ALTER TABLE [dbo].[Pre_Procurement]  WITH CHECK ADD  CONSTRAINT [fk_ProProductID] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[tlb_Products] ([ID])
GO
ALTER TABLE [dbo].[Pre_Procurement] CHECK CONSTRAINT [fk_ProProductID]
GO
ALTER TABLE [dbo].[Pre_Products]  WITH CHECK ADD  CONSTRAINT [fk_BrandID] FOREIGN KEY([Brand_ID])
REFERENCES [dbo].[tlb_Brand] ([ID])
GO
ALTER TABLE [dbo].[Pre_Products] CHECK CONSTRAINT [fk_BrandID]
GO
ALTER TABLE [dbo].[Pre_Products]  WITH CHECK ADD  CONSTRAINT [fk_ColorID] FOREIGN KEY([Color_ID])
REFERENCES [dbo].[tlb_Color] ([ID])
GO
ALTER TABLE [dbo].[Pre_Products] CHECK CONSTRAINT [fk_ColorID]
GO
ALTER TABLE [dbo].[Pre_Products]  WITH CHECK ADD  CONSTRAINT [fk_DomainID] FOREIGN KEY([Domain_ID])
REFERENCES [dbo].[tb_Domain] ([ID])
GO
ALTER TABLE [dbo].[Pre_Products] CHECK CONSTRAINT [fk_DomainID]
GO
ALTER TABLE [dbo].[Pre_Products]  WITH CHECK ADD  CONSTRAINT [fk_modelID] FOREIGN KEY([Model_No_ID])
REFERENCES [dbo].[tlb_Model] ([ID])
GO
ALTER TABLE [dbo].[Pre_Products] CHECK CONSTRAINT [fk_modelID]
GO
ALTER TABLE [dbo].[Pre_Products]  WITH CHECK ADD  CONSTRAINT [fk_PCategoryID] FOREIGN KEY([P_Category])
REFERENCES [dbo].[tlb_P_Category] ([ID])
GO
ALTER TABLE [dbo].[Pre_Products] CHECK CONSTRAINT [fk_PCategoryID]
GO
ALTER TABLE [dbo].[Pre_Products]  WITH CHECK ADD  CONSTRAINT [fk_ProductID] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[tlb_Products] ([ID])
GO
ALTER TABLE [dbo].[Pre_Products] CHECK CONSTRAINT [fk_ProductID]
GO
ALTER TABLE [dbo].[StockDetails]  WITH CHECK ADD  CONSTRAINT [fk_B_StockDetailsID] FOREIGN KEY([Brand_ID])
REFERENCES [dbo].[tlb_Brand] ([ID])
GO
ALTER TABLE [dbo].[StockDetails] CHECK CONSTRAINT [fk_B_StockDetailsID]
GO
ALTER TABLE [dbo].[StockDetails]  WITH CHECK ADD  CONSTRAINT [fk_C_StockDetailsID] FOREIGN KEY([Color_ID])
REFERENCES [dbo].[tlb_Color] ([ID])
GO
ALTER TABLE [dbo].[StockDetails] CHECK CONSTRAINT [fk_C_StockDetailsID]
GO
ALTER TABLE [dbo].[StockDetails]  WITH CHECK ADD  CONSTRAINT [fk_D_StockDetailsID] FOREIGN KEY([Domain_ID])
REFERENCES [dbo].[tb_Domain] ([ID])
GO
ALTER TABLE [dbo].[StockDetails] CHECK CONSTRAINT [fk_D_StockDetailsID]
GO
ALTER TABLE [dbo].[StockDetails]  WITH CHECK ADD  CONSTRAINT [fk_M_StockDetailsID] FOREIGN KEY([Model_No_ID])
REFERENCES [dbo].[tlb_Model] ([ID])
GO
ALTER TABLE [dbo].[StockDetails] CHECK CONSTRAINT [fk_M_StockDetailsID]
GO
ALTER TABLE [dbo].[StockDetails]  WITH CHECK ADD  CONSTRAINT [fk_P_StockDetailsID] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[tlb_Products] ([ID])
GO
ALTER TABLE [dbo].[StockDetails] CHECK CONSTRAINT [fk_P_StockDetailsID]
GO
ALTER TABLE [dbo].[StockDetails]  WITH CHECK ADD  CONSTRAINT [fk_PC_StockDetailsID] FOREIGN KEY([P_Category])
REFERENCES [dbo].[tlb_P_Category] ([ID])
GO
ALTER TABLE [dbo].[StockDetails] CHECK CONSTRAINT [fk_PC_StockDetailsID]
GO
ALTER TABLE [dbo].[tbl_EmployeePhoto]  WITH CHECK ADD  CONSTRAINT [fk_D_tbl_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[tbl_Employee] ([ID])
GO
ALTER TABLE [dbo].[tbl_EmployeePhoto] CHECK CONSTRAINT [fk_D_tbl_Employee]
GO
ALTER TABLE [dbo].[tlb_Brand]  WITH CHECK ADD  CONSTRAINT [fk_BID] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[tlb_Products] ([ID])
GO
ALTER TABLE [dbo].[tlb_Brand] CHECK CONSTRAINT [fk_BID]
GO
ALTER TABLE [dbo].[tlb_Color]  WITH CHECK ADD  CONSTRAINT [fk_CID] FOREIGN KEY([Model_No_ID])
REFERENCES [dbo].[tlb_Model] ([ID])
GO
ALTER TABLE [dbo].[tlb_Color] CHECK CONSTRAINT [fk_CID]
GO
ALTER TABLE [dbo].[tlb_FollowUp]  WITH CHECK ADD  CONSTRAINT [fk_Follow_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[tbl_Employee] ([ID])
GO
ALTER TABLE [dbo].[tlb_FollowUp] CHECK CONSTRAINT [fk_Follow_EmployeeID]
GO
ALTER TABLE [dbo].[tlb_FollowUpActivity]  WITH CHECK ADD  CONSTRAINT [fk_Follow_EmployeeIDActivity] FOREIGN KEY([AEmployeeID])
REFERENCES [dbo].[tbl_Employee] ([ID])
GO
ALTER TABLE [dbo].[tlb_FollowUpActivity] CHECK CONSTRAINT [fk_Follow_EmployeeIDActivity]
GO
ALTER TABLE [dbo].[tlb_FollowUpActivity]  WITH CHECK ADD  CONSTRAINT [fk_tlb_FollowUpIDAcivity] FOREIGN KEY([FollowupID])
REFERENCES [dbo].[tlb_FollowUp] ([ID])
GO
ALTER TABLE [dbo].[tlb_FollowUpActivity] CHECK CONSTRAINT [fk_tlb_FollowUpIDAcivity]
GO
ALTER TABLE [dbo].[tlb_FollowUpComments]  WITH CHECK ADD  CONSTRAINT [fk_tlb_FollowUpID1] FOREIGN KEY([FollowupID])
REFERENCES [dbo].[tlb_FollowUp] ([ID])
GO
ALTER TABLE [dbo].[tlb_FollowUpComments] CHECK CONSTRAINT [fk_tlb_FollowUpID1]
GO
ALTER TABLE [dbo].[tlb_FollowUpProducts]  WITH CHECK ADD  CONSTRAINT [fk_Pre_ProductsID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Pre_Products] ([ID])
GO
ALTER TABLE [dbo].[tlb_FollowUpProducts] CHECK CONSTRAINT [fk_Pre_ProductsID]
GO
ALTER TABLE [dbo].[tlb_FollowUpProducts]  WITH CHECK ADD  CONSTRAINT [fk_tlb_FollowUpProducts] FOREIGN KEY([FollowupID])
REFERENCES [dbo].[tlb_FollowUp] ([ID])
GO
ALTER TABLE [dbo].[tlb_FollowUpProducts] CHECK CONSTRAINT [fk_tlb_FollowUpProducts]
GO
ALTER TABLE [dbo].[tlb_Model]  WITH CHECK ADD  CONSTRAINT [fk_MID] FOREIGN KEY([P_Category])
REFERENCES [dbo].[tlb_P_Category] ([ID])
GO
ALTER TABLE [dbo].[tlb_Model] CHECK CONSTRAINT [fk_MID]
GO
ALTER TABLE [dbo].[tlb_P_Category]  WITH CHECK ADD  CONSTRAINT [fk_PCID] FOREIGN KEY([Brand_ID])
REFERENCES [dbo].[tlb_Brand] ([ID])
GO
ALTER TABLE [dbo].[tlb_P_Category] CHECK CONSTRAINT [fk_PCID]
GO
ALTER TABLE [dbo].[tlb_Products]  WITH CHECK ADD  CONSTRAINT [fk_PID] FOREIGN KEY([Domain_ID])
REFERENCES [dbo].[tb_Domain] ([ID])
GO
ALTER TABLE [dbo].[tlb_Products] CHECK CONSTRAINT [fk_PID]
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Product]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Add_Product]

	@Flag int=null,
	@Domain_Name nvarchar(MAX),
	@PAN_Card nvarchar(MAX),
	@Adhar_Card nvarchar(MAX) ,
	@Passport nvarchar(MAX),
	@Address_Proof nvarchar(MAX),
	@Seven_Twevel nvarchar(MAX),
	@Form_16 nvarchar(MAX),
	@Dealer_Lisence nvarchar(MAX),
	@Other_ID_Proof nvarchar(MAX),
	@No_Documents nvarchar(MAX),
	@Cmp_ID_Proof nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@Flag =1)
	begin
	Insert into tb_Domain(Domain_Name,PAN_Card ,Adhar_Card ,Passport ,Address_Proof ,Seven_Twevel ,Form_16 ,Dealer_Lisence,Other_ID_Proof,No_Documents ,Cmp_ID_Proof ,S_Status ,C_Date ) values (@Domain_Name ,@PAN_Card ,@Adhar_Card ,@Passport ,@Address_Proof ,@Seven_Twevel ,@Form_16 ,@Dealer_Lisence ,@Other_ID_Proof ,@No_Documents ,@Cmp_ID_Proof ,@S_Status ,@C_Date )
	end
	
END

GO
/****** Object:  StoredProcedure [dbo].[SP_AddActivity]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_AddActivity]
@Flag int=null,
@FollowupID int=null,
@ASubject nvarchar(MAX),
@ADate nvarchar(MAX),
@AEmployeeID int=null,
@ANotes nvarchar(MAX),
@S_Status nvarchar(MAX) ,
@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  if(@Flag=1)
  begin
  insert into tlb_FollowUpActivity(FollowupID,ASubject,ADate,AEmployeeID,ANotes,S_Status,C_Date) values (@FollowupID,@ASubject,@ADate,@AEmployeeID,@ANotes,@S_Status,@C_Date)
  end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ADDBrand]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ADDBrand]
	-- Add the parameters for the stored procedure here
	@Flag int=null,
	@Product_ID nvarchar(MAX),
	@Brand_Name nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if(@Flag =1)
begin
insert into  tlb_Brand(Product_ID,Brand_Name,S_Status,C_Date) values(@Product_ID ,@Brand_Name ,@S_Status ,@C_Date )
end
   
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ADDColor]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ADDColor]
	@Flag int=null,
	@Model_No_ID nvarchar(MAX),
	@Color nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date DateTime 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   if(@Flag=1)
  begin 
  insert into tlb_Color (Model_No_ID,Color,S_Status,C_Date) values (@Model_No_ID  ,@Color ,@S_Status ,@C_Date )
  end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_AddComments]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_AddComments] 
@Flag int=null,
@FollowupID int=null,
@Comments nvarchar(MAX),
@S_Status nvarchar(MAX) ,
@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
  if(@Flag=1)
  begin
  insert into tlb_FollowUpComments(FollowupID,Comments,S_Status,C_Date) values (@FollowupID,@Comments,@S_Status,@C_Date)
  end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ADDModel]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ADDModel]
	@Flag int=null,
	@P_Category nvarchar(MAX),
	@Model_No nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date DateTime 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  if(@Flag=1)
  begin 
  insert into tlb_Model (P_Category,Model_No,S_Status,C_Date) values (@P_Category ,@Model_No ,@S_Status ,@C_Date )
  end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ADDP_Category]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ADDP_Category]
	-- Add the parameters for the stored procedure here
	@Flag int=null,
	@Brand_ID nvarchar(MAX),
	@Product_Category nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date DateTime 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  if(@Flag=1)
  begin 
  insert into tlb_P_Category (Brand_ID,Product_Category,S_Status,C_Date) values (@Brand_ID ,@Product_Category ,@S_Status ,@C_Date )
  end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ADDProducts]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ADDProducts]
	-- Add the parameters for the stored procedure here
	@Flag int=null,
	
	@Domain_ID int=null,
	@Product_Name nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if(@Flag =1)
	begin
	insert into tlb_Products (Domain_ID,Product_Name,S_Status,C_Date) values (@Domain_ID ,@Product_Name ,@S_Status ,@C_Date )
	end
  
END

GO
/****** Object:  StoredProcedure [dbo].[SP_AddQtyStockDetails]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_AddQtyStockDetails] 
	@Flag int=null,
	@id int=null,
	@AvilableQty nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
	Update StockDetails Set AvilableQty=@AvilableQty Where id=@id 
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_BalanceDefaultSMS]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_BalanceDefaultSMS]
    @Flag int=null,
	@SelectCategory nvarchar(MAX),
	@DefaultDate nvarchar(Max),
	@DefaultMessage nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
	Insert Into tlb_CustomerBalance(SelectCategory, SMSDate, SMSMessage, S_Status, C_Date) Values (@SelectCategory, @DefaultDate, @DefaultMessage, @S_Status, @C_Date)
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Bill_No]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Bill_No]
	@Flag int=null,
	@Customer_ID int = NULL,
	@Employee_ID int=null,
@Bill_No nvarchar(MAX) ,
@Payment_Mode nvarchar(MAX),
@Total_Price money,
@Paid_Amount money,
@Balance_Amount money,
@S_Status nvarchar(MAX),
@C_Date nvarchar(MAX) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   if(@Flag =1)
   begin
   insert into tlb_Bill_No(Customer_ID,Employee_ID,Bill_No,Payment_Mode,Total_Price,Paid_Amount,Balance_Amount,S_Status,C_Date) values(@Customer_ID,@Employee_ID,@Bill_No,@Payment_Mode,@Total_Price,@Paid_Amount,@Balance_Amount,@S_Status ,@C_Date )
   end
END
GO
/****** Object:  StoredProcedure [dbo].[SP_C_Installment]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_C_Installment]
@Flag int=null,
@Customer_ID int=NULL,
@Bill_No nvarchar(MAX),
@Total_Price money ,
@Paid_Amount money ,
@Balance_Amount money ,
@Monthly_Amount money ,
@Total_Installment_Month nvarchar(MAX) ,
@Current_Installment_No nvarchar(MAX) ,
@Remaining_Installments nvarchar(MAX) ,
@Current_Installment_Amount money ,
@CInstallment_Date nvarchar(MAX),
@Paid_Unpaid nvarchar(MAX),
@S_Status nvarchar(MAX),
@C_Date nvarchar(MAX) 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   if(@Flag =1)
    begin
    insert into tlb_Customer_Installment(Customer_ID,Bill_No,Total_Price,Paid_Amount,Balance_Amount,Monthly_Amount,Total_Installment_Month,Current_Installment_No,Remaining_Installments,Current_Installment_Amount,CInstallment_Date,Paid_Unpaid,S_Status,C_Date) values(@Customer_ID ,@Bill_No ,@Total_Price ,@Paid_Amount ,@Balance_Amount ,@Monthly_Amount ,@Total_Installment_Month ,@Current_Installment_No ,@Remaining_Installments ,@Current_Installment_Amount,@CInstallment_Date,@Paid_Unpaid  ,@S_Status ,@C_Date )
    end
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckUpdateStatus]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CheckUpdateStatus] 
	@Flag int=null,
	@CheckID nvarchar(MAX),
	@IsClear nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@Flag =1)
	begin
	Update tlb_Cheque set IsClear=@IsClear Where ID=@CheckID
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_CreateCampaign]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateCampaign]
	@Flag int=null,
	@CampaignName nvarchar(MAX),
	@CampaignType nvarchar(MAX),
	@StartDate nvarchar(MAX) ,
	@EndDate nvarchar(MAX),
	@ExpectedRevenue money,
	@BudgetedCost money,
	@Status nvarchar(MAX),
	@ExpectedResponse nvarchar(MAX),
	@Description nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   if(@Flag =1)
	begin
	Insert into tlb_FollowUpCampaign(CampaignName,CampaignType ,StartDate ,EndDate ,ExpectedRevenue ,BudgetedCost ,Status ,ExpectedResponse,Description,S_Status ,C_Date ) values (@CampaignName,@CampaignType ,@StartDate ,@EndDate ,@ExpectedRevenue ,@BudgetedCost ,@Status ,@ExpectedResponse,@Description,@S_Status ,@C_Date )
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Customer]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Customer]
	@Flag int=null,
	@Cust_ID nvarchar(MAX) ,
@FirstName nvarchar(MAX),
@LastName nvarchar(MAX),
@Occupation nvarchar(MAX) ,
@Date_Of_Birth nvarchar(MAX) ,
@Mobile_No nvarchar(MAX) ,
@PhoneNo nvarchar(MAX),
@Email_ID nvarchar(MAX) ,
@Address nvarchar(MAX),
@City nvarchar(MAX),
@ZipNo nvarchar(MAX),
@State nvarchar(MAX),
@Country nvarchar(MAX),
@SourceOfEnquiry nvarchar(MAX),
@SourceEnquiryID int=null,
@S_Status nvarchar(MAX) ,
@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@Flag =1)
	begin
	insert into  tlb_Customer (Cust_ID,FirstName,LastName,Occupation,Date_Of_Birth,Mobile_No,PhoneNo,Email_ID,Address,City,ZipNo,State,Country,SourceOfEnquiry,SourceEnquiryID,S_Status,C_Date) values (@Cust_ID,@FirstName,@LastName,@Occupation,@Date_Of_Birth,@Mobile_No,@PhoneNo,@Email_ID,@Address,@City,@ZipNo,@State,@Country,@SourceOfEnquiry,@SourceEnquiryID,@S_Status,@C_Date)
	end 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Customer_Followup_Update]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Customer_Followup_Update]
	@Flag int=null,
	@F_ID int=null,
	@S_Status nvarchar(MAX) ,
@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@Flag =1)
	begin
	Update tlb_FollowUp set S_Status=@S_Status,C_Date=@C_Date where ID=@F_ID
	end
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CustomerFollowupDefaultSMS]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CustomerFollowupDefaultSMS]
	@Flag int=null,
	@SelectCategory nvarchar(MAX),
	@DefaultDate nvarchar(Max),
	@DefaultMessage nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
	Insert Into tlb_CustomerFollowupDefaultSMS(SelectCategory, SMSDate, SMSMessage, S_Status, C_Date) Values (@SelectCategory, @DefaultDate, @DefaultMessage, @S_Status, @C_Date)
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DealerEntry]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DealerEntry]
	@Flag int=null,
	@id int=null,
	@DealerEntryID nvarchar(MAX),
	@CompanyName nvarchar(MAX),
	@DealerFirstName nvarchar(MAX),
	@DealerLastName nvarchar(MAX),
	@DateOfBirth nvarchar(MAX),
	@MobileNo nvarchar(MAX),
	@PhoneNo nvarchar(MAX),
	@DealerAddress nvarchar(MAX),
	@City nvarchar(MAX),
	@Zip nvarchar(MAX),
	@DState nvarchar(MAX),
	@Country nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@Flag = 1)
	begin
	Insert Into tbl_DealerEntry(DealerEntryID, CompanyName, DealerFirstName, DealerLastName, DateOfBirth, MobileNo, PhoneNo, DealerAddress, City, Zip, DState, Country, S_Status, C_Date) values (@DealerEntryID, @CompanyName, @DealerFirstName, @DealerLastName, @DateOfBirth, @MobileNo, @PhoneNo, @DealerAddress, @City, @Zip, @DState, @Country, @S_Status, @C_Date) 
	end

	if(@Flag = 2)
	begin
	Update tbl_DealerEntry Set DealerEntryID=@DealerEntryID, CompanyName=@CompanyName, DealerFirstName = @DealerFirstName, DealerLastName = @DealerLastName, DateOfBirth = @DateOfBirth, MobileNo = @MobileNo, PhoneNo = @PhoneNo, DealerAddress = @DealerAddress, City = @City, Zip = @Zip, DState = @DState, Country = @Country, S_Status = @S_Status Where ID=@id
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DealerFollowupDefaultSMS]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DealerFollowupDefaultSMS]
	@Flag int=null,
	@SelectCategory nvarchar(MAX),
	@DefaultDate nvarchar(Max),
	@DefaultMessage nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
	Insert Into tlb_DealerFollowupDefaultSMS(SelectCategory, SMSDate, SMSMessage, S_Status, C_Date) Values (@SelectCategory, @DefaultDate, @DefaultMessage, @S_Status, @C_Date)
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DefaultSMS]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DefaultSMS]
	@Flag int=null,
	@SelectCategory nvarchar(MAX),
	@DefaultDate nvarchar(Max),
	@DefaultMessage nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
	Insert Into tlb_DefaultCustomerBirthdaySMS(SelectCategory, SMSDate, SMSMessage, S_Status, C_Date) Values (@SelectCategory, @DefaultDate, @DefaultMessage, @S_Status, @C_Date)
	end
    
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Employee]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Employee]
	@Flag int=null,
	@id int=null,
	@EmployeeID nvarchar (MAX),
	@EmployeeFirstName nvarchar(MAX),
	@EmployeeLastName nvarchar(MAX),
	@DateOfBirth nvarchar(MAX),
	@MobileNo nvarchar(MAX),
	@PhoneNo nvarchar(MAX),
	@EmpAddress nvarchar(MAX),
	@EmpCity nvarchar(MAX),
	@EmpZipNo nvarchar(MAX),
	@EmpState  nvarchar(MAX),
	@EmpCountry nvarchar(MAX),
	@Designation nvarchar(MAX),
	@DateOfJoining nvarchar(MAX),
	@NoOfYears nvarchar(MAX),
	@Years nvarchar(MAX),
	@NoOfMonths nvarchar(MAX),
	@Months nvarchar(MAX),
	@Salary money,
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
	Insert Into tbl_Employee(EmployeeID, EmployeeFirstName, EmployeeLastName, DateOfBirth,  MobileNo, PhoneNo, EmpAddress, EmpCity, EmpZipNo, EmpState, EmpCountry, Designation, DateOfJoining, NoOfYears, Years, NoOfMonths, Months, Salary, S_Status, C_Date) Values (@EmployeeID, @EmployeeFirstName, @EmployeeLastName, @DateOfBirth, @MobileNo, @PhoneNo, @EmpAddress, @EmpCity, @EmpZipNo, @EmpState, @EmpCountry, @Designation, @DateOfJoining, @NoOfYears, @Years, @NoOfMonths, @Months, @Salary, @S_Status, @C_Date)
	end
	if(@Flag = 2)
	begin
	Update tbl_Employee Set EmployeeID = @EmployeeID, EmployeeFirstName=@EmployeeFirstName, DateOfBirth=@DateOfBirth, EmpAddress=@EmpAddress, MobileNo=@MobileNo, PhoneNo=@PhoneNo, Designation=@Designation, DateOfJoining=@DateOfJoining, NoOfYears=@NoOfYears, Years=@Years, NoOfMonths=@NoOfMonths, Months=@Months, Salary=@Salary, S_Status=@S_Status, C_Date=@C_Date Where [ID]=@id
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EmployeePhoto]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_EmployeePhoto] 
	@Flag int=null,
	@EmployeeID int=null,
	@PhotoPath nvarchar(MAX),
	@EmpPhoto image,
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
	Insert Into tbl_EmployeePhoto(EmployeeID,PhotoPath,EmpImage,S_Status,C_Date) values (@EmployeeID,@PhotoPath,@EmpPhoto,@S_Status,@C_Date)
	end
  
END

GO
/****** Object:  StoredProcedure [dbo].[SP_FinalDealer]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_FinalDealer] 
	@Flag int=null,
	@Dealer_ID int=null,
	@SalesID nvarchar(MAX),
	@Domain_ID int=null,
	@Product_ID int=null,
	@Brand_ID int=null,
	@P_Category int=null,
	@Model_No_ID int=null,
	@Color_ID int=null,
	@ProcNetAmt money,
	@ProcPrice money,
	@ProcQty nvarchar(MAX),
	@FinalPrice money,
	@FinalQty nvarchar(MAX),
	@SubTotal money,
	@RoundUp money,
	@NetAmt money,
	@SDefault nvarchar(MAX),
	@ServiceIntervalMonth nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
    Insert Into Final_DealerDetails (Dealer_ID,SalesID,Domain_ID,Product_ID,Brand_ID,P_Category,Model_No_ID,Color_ID,ProcNetAmt,ProcPrice,ProcQty,FinalPrice,FinalQty,SubTotal,RoundUp,NetAmt,SDefault,ServiceIntervalMonth,S_Status,C_Date) Values (@Dealer_ID,@SalesID,@Domain_ID,@Product_ID,@Brand_ID,@P_Category,@Model_No_ID,@Color_ID,@ProcNetAmt,@ProcPrice,@ProcQty,@FinalPrice,@FinalQty,@SubTotal,@RoundUp,@NetAmt,@SDefault,@ServiceIntervalMonth,@S_Status,@C_Date)
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_FinalDealerUpdateStatus]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_FinalDealerUpdateStatus] 
	@Flag int=null,
	@DealerID int=null,
	@S_Status nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Update Pre_Procurement Set S_Status=@S_Status Where DealerID=@DealerID
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Followup]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Followup]
	-- Add the parameters for the stored procedure here
	@Flag int=null,
@EmployeeID int=null,
@Followup_ID nvarchar(MAX) ,
@FTitle nvarchar(MAX),
@FiratName nvarchar(MAX) ,
@LastName nvarchar(MAX),
@Date_Of_Birth nvarchar(MAX),
@Mobile_No nvarchar(MAX),
@PhoneNo nvarchar(MAX),
@SourceOfEnquiry nvarchar(MAX) ,
@SourceEnquiryID int=null,
@Occupation nvarchar(MAX) ,
@AnnualRevenue money,
@Email_ID nvarchar(MAX),
@FaxNo nvarchar(MAX),
@Wbsite nvarchar(MAX),
@Street nvarchar(MAX) ,
@City nvarchar(MAX),
@State nvarchar(MAX),
@ZipNo nvarchar(MAX),
@Country nvarchar(MAX),
@Description nvarchar(MAX) ,
@F_Date nvarchar(MAX),
@S_Status nvarchar(MAX) ,
@C_Date nvarchar(MAX)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  if(@Flag=1)
  begin
  insert into tlb_FollowUp(EmployeeID,Followup_ID,FTitle,FiratName,LastName,Date_Of_Birth,Mobile_No,Phone_No,SourceOfEnquiry,SourceEnquiryID,Occupation,AnnualRevenue,Email_ID,FaxNo,Wbsite,Street,City,State,ZipNo,Country,Description,F_Date,S_Status,C_Date)values(@EmployeeID,@Followup_ID,@FTitle,@FiratName,@LastName,@Date_Of_Birth,@Mobile_No,@PhoneNo,@SourceOfEnquiry,@SourceEnquiryID,@Occupation,@AnnualRevenue,@Email_ID,@FaxNo,@Wbsite,@Street,@City,@State,@ZipNo,@Country,@Description,@F_Date,@S_Status,@C_Date)
  end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Followup2]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Followup2]
	-- Add the parameters for the stored procedure here
	@Flag int=null,
	@Followup_ID nvarchar(MAX) ,
@Name nvarchar(MAX) ,
@Mobile_No nvarchar(MAX),
@Date_Of_Birth nvarchar(MAX),
@Email_ID nvarchar(MAX),
@Address nvarchar(MAX) ,
@Occupation nvarchar(MAX) ,
@Product_Details nvarchar(MAX) ,
@Followup_Type nvarchar(MAX),
@Folloup_Update nvarchar(MAX) ,
@S_Status nvarchar(MAX) ,
@C_Date nvarchar(MAX) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 
  if(@Flag=1)
  begin
  insert into tlb_FollowUp(Followup_ID,Name,Mobile_No,Date_Of_Birth,Email_ID,Address,Occupation,Product_Details ,Followup_Type,Folloup_Update ,S_Status,C_Date)values(@Followup_ID,@Name ,@Mobile_No,@Date_Of_Birth ,@Email_ID  ,@Address,@Occupation ,@Product_Details ,@Followup_Type, @Folloup_Update ,@S_Status,@C_Date  )
  end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_FollowUpProducts]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_FollowUpProducts]
	@Flag int=null,
	@FolloupProductID int=null,
@FProductID int=null,
@S_Status nvarchar(MAX) ,
@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag=1)
  begin
  insert into tlb_FollowUpProducts(FollowupID,ProductID,S_Status,C_Date) values (@FolloupProductID,@FProductID,@S_Status,@C_Date)
  end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_InsuranceDefaultSMS]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_InsuranceDefaultSMS]
	@Flag int=null,
	@SelectCategory nvarchar(MAX),
	@DefaultDate nvarchar(Max),
	@DefaultMessage nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
	Insert Into tlb_InsuranceDefaultSMS(SelectCategory, SMSDate, SMSMessage, S_Status, C_Date) Values (@SelectCategory, @DefaultDate, @DefaultMessage, @S_Status, @C_Date)
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_InsuranceEntry]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_InsuranceEntry] 
	@Flag int=null,
	@InsuranceID int=null,
	@Customer_ID int=null,
	@InsuranceNo nvarchar(MAX),
	@ProductName nvarchar(MAX),
	@InsuranceAmt Money,
	@BankName nvarchar(MAX),
	@InsuranceDate nvarchar(MAX),
	@NoOfYearMonths int=null,
	@NoOfMonth int=null,
	@YearsMonths nvarchar(MAX),
	@IntervalMonths int=null,
	@IntervalMonthY nvarchar(MAX),
	@IntervalAmt money,
	@NewInsuranceDate nvarchar(MAX),
	@FirstPartyInsurance varchar(MAX),
	@IsClear nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
	Insert into tlb_InsuranceEntry(Customer_ID,InsuranceNo,ProductName,InsuranceAmt,BankName,InsuranceDate,NoOfYearMonths,NoOfMonth,YearsMonths,IntervalMonths,IntervalMonthY,IntervalAmt,NewInsuranceDate,FirstPartyInsurance,IsClear,S_Status,C_Date) Values (@Customer_ID,@InsuranceNo,@ProductName,@InsuranceAmt,@BankName,@InsuranceDate,@NoOfYearMonths,@NoOfMonth,@YearsMonths,@IntervalMonths,@IntervalMonthY,@IntervalAmt,@NewInsuranceDate,@FirstPartyInsurance,@IsClear,@S_Status,@C_Date)
	end

	if(@Flag = 2)
	begin
	Update tlb_InsuranceEntry Set Customer_ID=@Customer_ID,InsuranceNo=@InsuranceNo,ProductName=@ProductName,InsuranceAmt=@InsuranceAmt,BankName=@BankName,InsuranceDate=@InsuranceDate,NoOfYearMonths=@NoOfYearMonths,NoOfMonth=@NoOfMonth,YearsMonths=@YearsMonths,IntervalMonths=@IntervalMonths,IntervalMonthY=@IntervalMonthY,IntervalAmt=@IntervalAmt,NewInsuranceDate=@NewInsuranceDate,FirstPartyInsurance=@FirstPartyInsurance,IsClear=@IsClear,S_Status=@S_Status,C_Date=@C_Date Where ID=@InsuranceID
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_InvoiceDetails]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_InvoiceDetails]
	@Flag int=null,
	@Customer_ID int=null ,
    @Bill_No nvarchar(MAX) ,
@Domain_ID int=null ,
 @Product_ID int=null ,
 @Brand_ID int=null ,
 @P_Category int=null ,
 @Model_No_ID int=null ,
 @Color_ID int=null ,
@Products123 nvarchar(MAX),
@Per_Product_Price  money ,
@Qty  money ,
@C_Price  money ,
@Tax_Name nvarchar(MAX) ,
@Tax  money ,
@Total_Price  money ,
@Payment_Mode  nvarchar(MAX),
@S_Status nvarchar(MAX),
@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if(@Flag=1)
begin
insert into tlb_InvoiceDetails(Customer_ID,Bill_No,Domain_ID,Product_ID,Brand_ID,P_Category,Model_No_ID,Color_ID,Products123,Per_Product_Price ,Qty,C_Price,Tax_Name ,Tax,Total_Price,Payment_Mode ,S_Status ,C_Date) values (@Customer_ID ,@Bill_No ,@Domain_ID ,@Product_ID ,@Brand_ID ,@P_Category ,@Model_No_ID ,@Color_ID ,@Products123 ,@Per_Product_Price ,@Qty ,@C_Price ,@Tax_Name ,@Tax ,@Total_Price,@Payment_Mode  ,@S_Status ,@C_Date )
end 
   
END

GO
/****** Object:  StoredProcedure [dbo].[SP_MainInstallment]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_MainInstallment]
@Flag int=null,
@Customer_ID int=NULL,
@Bill_No nvarchar(MAX) ,
@Total_Price money  ,
@Paid_Amount money  ,
@Balance_Amount money  ,
@Monthly_Amount money  ,
@Installment_Year nvarchar(MAX) ,
@Installment_Month nvarchar(MAX) ,
@Installment_Date nvarchar(MAX),
@S_Status nvarchar(MAX),
@C_Date nvarchar(MAX) 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if(@Flag =1)
    begin
    insert into tlb_MainInstallment(Customer_ID,Bill_No,Total_Price,Paid_Amount,Balance_Amount,Monthly_Amount,Installment_Year,Installment_Month,Installment_Date,S_Status,C_Date) values(@Customer_ID ,@Bill_No ,@Total_Price ,@Paid_Amount ,@Balance_Amount ,@Monthly_Amount ,@Installment_Year ,@Installment_Month ,@Installment_Date ,@S_Status ,@C_Date )
    end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_PaymentMode]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_PaymentMode]
	@Flag int=null,
	@Customer_ID int=NULL,
@Bill_No nvarchar(MAX),
@Total_Price money ,
@Paid_Amount money ,
@Balance_Amount money ,
@S_Status nvarchar(MAX),
@C_Date nvarchar(MAX) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@Flag =1)
	begin
	insert into tlb_Cash (Customer_ID,Bill_No,Total_Price,Paid_Amount,Balance_Amount,S_Status,C_Date) values(@Customer_ID ,@Bill_No ,@Total_Price ,@Paid_Amount ,@Balance_Amount ,@S_Status ,@C_Date ) 
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_PaymentMode_Cheque]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_PaymentMode_Cheque]
@Flag int=null,
@Customer_ID int = NULL,
@Bill_No nvarchar(MAX)  ,
@Total_Price money ,
@Cheque_Amount money ,
@Cheque_No nvarchar(MAX)  ,
@Cheque_Date nvarchar(MAX) ,
@Cheque_Bank_Name nvarchar(MAX) ,
@IsClear nvarchar(MAX),
@S_Status nvarchar(MAX),
@C_Date nvarchar(MAX) 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   if(@Flag =1)
   begin
   insert into tlb_Cheque(Customer_ID,Bill_No,Total_Price,Cheque_Amount,Cheque_No,Cheque_Date,Cheque_Bank_Name,IsClear,S_Status,C_Date) values (@Customer_ID ,@Bill_No ,@Total_Price ,@Cheque_Amount ,@Cheque_No ,@Cheque_Date ,@Cheque_Bank_Name ,@IsClear,@S_Status,@C_Date )
   end
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Pre_Procurement_Save]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Pre_Procurement_Save]
	@Flag int=null,

 @DealerID int=null,
 @Domain_ID int=null,
 @Product_ID int=null,
 @Brand_ID int=null,
 @P_Category int=null,
 @Model_No_ID int=null,
 @Color_ID int=null,
 
 @Procurment_Price money ,
 @Quantity money ,
 @Total_Amount money ,
 @Net_Amount money ,
 @Round_Off money ,
 @Reg_Document  nvarchar(MAX),
 @Have_Insurance  nvarchar(MAX),
 @Warranty  nvarchar(MAX),
 @re_ferb_cost nvarchar(MAX),
 @Follow_up nvarchar(MAX),
 @Narration nvarchar(MAX),
@PendingPreProc nvarchar(MAX), 
 @S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if(@Flag =1)
   begin
   insert into Pre_Procurement(DealerID,Domain_ID,Product_ID,Brand_ID,P_Category,Model_No_ID,Color_ID,Procurment_Price,Quantity,Total_Amount,Net_Amount,Round_Off,Reg_Document,Have_Insurance,Warranty,re_ferb_cost,Follow_up,Narration,PendingPreProc,S_Status,C_Date) values(@DealerID,@Domain_ID ,@Product_ID ,@Brand_ID ,@P_Category ,@Model_No_ID ,@Color_ID ,@Procurment_Price,@Quantity,@Total_Amount,@Net_Amount,@Round_Off,@Reg_Document ,@Have_Insurance, @Warranty, @re_ferb_cost ,@Follow_up ,@Narration, @PendingPreProc ,@S_Status,@C_Date  )
   end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Save]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Save]
	@Flag int=null,
	@Domain_ID int=null,
 @Product_ID int=null,
 @Brand_ID int=null,
 @P_Category int=null,
 @Model_No_ID int=null,
 @Color_ID int=null,
 @Narration nvarchar(MAX),
 @Price money ,
 @S_Status nvarchar(MAX),
	@C_Date DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if(@Flag =1)
   begin
   insert into Pre_Products(Domain_ID,Product_ID,Brand_ID,P_Category,Model_No_ID,Color_ID,Narration,Price,S_Status,C_Date) values(@Domain_ID ,@Product_ID ,@Brand_ID ,@P_Category ,@Model_No_ID ,@Color_ID ,@Narration ,@Price,@S_Status,@C_Date  )
   end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_StockDetails]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_StockDetails]
	@Flag int=null,
	@id int=null,
	@DomainID int=null,
	@ProductID int=null,
	@BrandID int=null,
	@ProductCatID int=null,
	@ModelID int=null,
	@ColorId int=null,
	@Products123 nvarchar(MAX),
	@AvilableQty nvarchar(MAX),
	@SaleQty nvarchar(MAX),
	@NewQty nvarchar(MAX),
	@FinalPrice money,
	@HaveInsurance nvarchar(MAX),
	@Warranty nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
    Insert Into StockDetails(Domain_ID,Product_ID,Brand_ID,P_Category,Model_No_ID,Color_ID,Products123,AvilableQty,SaleQty,NewQty,FinalPrice,HaveInsurance,Warranty,S_Status,C_Date) Values (@DomainID,@ProductID,@BrandID,@ProductCatID,@ModelID,@ColorID,@Products123,@AvilableQty,@SaleQty,@NewQty,@FinalPrice,@HaveInsurance,@Warranty,@S_Status,@C_Date)
	end
	
	if(@Flag = 2)
	begin
	update StockDetails Set AvilableQty=@AvilableQty,S_Status=@S_Status,C_Date=@C_Date Where [ID]=@id
	end 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_StockDetailsUpdate]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_StockDetailsUpdate] 
	@Flag int=null,
	@id int=null,
	@NewQty nvarchar(MAX),
	@FinalPrice money,
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if(@Flag = 1)
	begin
	update StockDetails Set NewQty=@NewQty,FinalPrice=@FinalPrice,S_Status=@S_Status,C_Date=@C_Date Where [ID]=@id
	end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Tax_Save]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Tax_Save]
	@Flag int=null,
	@Tax_Type nvarchar(MAX),
	@Tax_Percentage money,
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if(@Flag =1)
begin
insert into tlb_AddTax(Tax_Type,Tax_Percentage,S_Status ,C_Date) values (@Tax_Type ,@Tax_Percentage ,@S_Status ,@C_Date )
end

   
END


GO
/****** Object:  StoredProcedure [dbo].[SP_update_Qty]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_update_Qty]
	@Flag int=null,
	@Products123 nvarchar(MAX),
	@AvilableQty money,
    @SaleQty  money ,
    @S_Status nvarchar(MAX),
    @C_Date nvarchar(MAX)
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   if(@Flag=1)
   begin
  update StockDetails Set AvilableQty=@AvilableQty ,SaleQty=@SaleQty  Where Products123=@Products123  and S_Status=@S_Status
  end
END

GO
/****** Object:  StoredProcedure [dbo].[SP_WarantyDefaultSMS]    Script Date: 10-09-2014 11:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_WarantyDefaultSMS]
	@Flag int=null,
	@SelectCategory nvarchar(MAX),
	@DefaultDate nvarchar(Max),
	@DefaultMessage nvarchar(MAX),
	@S_Status nvarchar(MAX),
	@C_Date nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 1)
	begin
	Insert Into tlb_Waranty(SelectCategory, SMSDate, SMSMessage, S_Status, C_Date) Values (@SelectCategory, @DefaultDate, @DefaultMessage, @S_Status, @C_Date)
	end
END

GO
