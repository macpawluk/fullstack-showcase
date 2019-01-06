import csLogo from "./../../../images/cs-logo.png";
import jojoLogo from "./../../../images/jojo-logo.png";
import ubsLogo from "./../../../images/ubs-logo.png";
import unit4Logo from "./../../../images/unit4-logo.png";

export interface IProjectDescriptor {
  id: string;
  companyName: string;
  duration: string;
  image: any;
  projectBulletItems: string[];
  techLabels: string[];
}

export const projectDescriptors: IProjectDescriptor[] = [
  {
    id: "2016_UBS",
    companyName: "UBS",
    duration: "2 years",
    image: ubsLogo,
    projectBulletItems: [
      "Implementation of application for GDPR (regulation) data processing",
      "Conducting technical interviews for the organization",
      "Migration of trading desk's strategy application to WPF"
    ],
    techLabels: [
      ".NET Core",
      "React",
      "Redux",
      "MS SQL",
      ".NET C#",
      "WPF",
      "WCF",
      "Oracle"
    ]
  },
  {
    id: "2014_CS",
    companyName: "Credit Suisse",
    duration: "1.5 year",
    image: csLogo,
    projectBulletItems: [
      "Listed products trading aplication development",
      "Files repository component fullstack development"
    ],
    techLabels: [".NET C#", "Silverlight", "WPF", "WCF"]
  },
  {
    id: "2010_JOJO",
    companyName: "Jojo Mobile",
    duration: "4 years",
    image: jojoLogo,
    projectBulletItems: [
      "Mobile apps and games development (Windows Phone platform)",
      "Group leadership"
    ],
    techLabels: [".NET C#", "Silverlight", "XNA", "XAML", "WCF"]
  },
  {
    id: "2006_TETA",
    companyName: "Teta",
    duration: "4 years",
    image: unit4Logo,
    projectBulletItems: [
      "ERP base framework development",
      "Bookkeeping module fullstack development",
      "SharePoint development"
    ],
    techLabels: [".NET C#", "Windows Forms", "Oracle"]
  }
];
