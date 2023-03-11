// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function ColourTypeToner() {
   var colourType = $("#colourType option:selected").val();
   if (colourType == "1") {
      $("#MachineColourType").nextAll(".bwPaperRate, .colourPaperRate, .bwToner, .cyanToner, .magentaToner, .yellowToner, .blackToner").remove();
      $("#MachineColourType").after(`<!-- BWPaperPerRate -->
                                          <div class="row mb-3 bwPaperRate">
                                             <label for="bwPaperRate" class="col-4 col-form-label">BW Paper Rate</label>
                                             <div class="col-8">
                                                <input type="text" class="form-control theme-black" id="bwPaperRate" placeholder="Enter Black &amp; White Paper Rate.." data-val="true" data-val-number="The field BW Paper Rate must be a number." name="BWPaperRate" value="">
                                                <span class="text-danger field-validation-valid" data-valmsg-for="BWPaperRate" data-valmsg-replace="true"></span>
                                             </div>
                                          </div>

                                          <!-- BW Toner Serial No -->
                                          <div class="row mb-3 bwToner">
                                             <label for="bwSerialNo" class="col-4 col-form-label">BW SerialNo</label>
                                             <div class="col-8">
                                                <input type="text" class="form-control theme-black" id="bwSerialNo" placeholder="Enter bw serial no.." name="BWSerialNo" value="">
                                                <span class="text-danger field-validation-valid" data-valmsg-for="BWSerialNo" data-valmsg-replace="true"></span>
                                             </div>
                                          </div>`);

   }
   else if (colourType == "2") {
      $("#MachineColourType").nextAll(".bwPaperRate, .colourPaperRate, .bwToner, .cyanToner, .magentaToner, .yellowToner, .blackToner").remove();
      $("#MachineColourType").after(`<!-- ColourPaperPerRate -->
                                        <div class="row mb-3 colourPaperRate">
                                          <label for="colourPaperRate" class="col-4 col-form-label">Colour Paper Rate</label>
                                          <div class="col-8">
                                             <input type="text" class="form-control theme-black" id="colourPaperRate" placeholder="Enter Colur Paper Rate.." data-val="true" data-val-number="The field Colour Paper Rate must be a number." name="ColourPaperRate" value="">
                                             <span class="text-danger field-validation-valid" data-valmsg-for="ColourPaperRate" data-valmsg-replace="true"></span>
                                          </div>
                                       </div>

                                       <!-- Cyan Toner Serial No -->
                                       <div class="row mb-3 cyanToner">
                                             <label for="cyanSerialNo" class="col-4 col-form-label">Cyan SerialNo</label>
                                             <div class="col-8">
                                                <input type="text" class="form-control theme-black" id="cyanSerialNo" placeholder="Enter cyan serial no.." name="CyanSerialNo" value="">
                                                <span class="text-danger field-validation-valid" data-valmsg-for="CyanSerialNo" data-valmsg-replace="true"></span>
                                             </div>
                                       </div>

                                       <!-- Magenta Toner Serial No -->
                                       <div class="row mb-3 magentaToner">
                                          <label for="magentaSerialNo" class="col-4 col-form-label">Magenta SerialNo</label>
                                          <div class="col-8">
                                             <input type="text" class="form-control theme-black" id="magentaSerialNo" placeholder="Enter magenta serial no.." name="MagentaSerialNo" value="">
                                             <span class="text-danger field-validation-valid" data-valmsg-for="MagentaSerialNo" data-valmsg-replace="true"></span>
                                          </div>
                                       </div>

                                       <!-- Yellow Toner Serial No -->
                                       <div class="row mb-3 yellowToner">
                                          <label for="yellowSerialNo" class="col-4 col-form-label">Yellow SerialNo</label>
                                          <div class="col-8">
                                             <input type="text" class="form-control theme-black" id="yellowSerialNo" placeholder="Enter yellow serial no.." name="YellowSerialNo" value="">
                                             <span class="text-danger field-validation-valid" data-valmsg-for="YellowSerialNo" data-valmsg-replace="true"></span>
                                          </div>
                                       </div>

                                       <!-- Black Toner Serial No -->
                                       <div class="row mb-3 blackToner">
                                          <label for="blackSerialNo" class="col-4 col-form-label">Black SerialNo</label>
                                          <div class="col-8">
                                             <input type="text" class="form-control theme-black" id="blackSerialNo" placeholder="Enter black serial no.." name="BlackSerialNo" value="" pwa2-uuid="EDITOR/input-5ED-42E-A6716-D17" pwa-fake-editor="">
                                             <span class="text-danger field-validation-valid" data-valmsg-for="BlackSerialNo" data-valmsg-replace="true"></span>
                                          </div>
                                       </div>`)
   }
};