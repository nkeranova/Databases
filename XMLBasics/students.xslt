<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <!--<xsl:output method="xml" indent="yes"/>-->

    <!--<xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        
        </xsl:copy>-->
      <xsl:template match="/">
      <html>
      <body>
        <h2>Students</h2>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th>Name</th>
            <th>Gender</th>
            <th>Birth date</th>
            <th>Email</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty number</th>
            <th>Exams</th>
          </tr>
          <xsl:for-each select="students/student">
            <tr>
              <td><xsl:value-of select="name"/></td>
              <td><xsl:value-of select="gender"/></td>
              <td><xsl:value-of select="birthdate"/></td>
              <td><xsl:value-of select="phone"/></td>
              <td><xsl:value-of select="email"/></td>
              <td><xsl:value-of select="course"/></td>
              <td><xsl:value-of select="specialty"/></td>
              <td><xsl:value-of select="facultynumber"/></td>
              <td><xsl:value-of select="exams"/></td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
    </xsl:template>
</xsl:stylesheet>

<!--Create XML document students.xml, which contains structured description of students.
For each student you should enter information for his name, sex, birth date, phone, email, course, specialty, faculty number and a list of taken exams (exam name, tutor, score).-->